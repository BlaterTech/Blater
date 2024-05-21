using System.Linq.Expressions;
using System.Reflection;
using Blater.Query.Interfaces;

namespace Blater.Query;

public class QueryOptimizer : ExpressionVisitor, IQueryOptimizer
{
    //TODO replace this with full type name?
    private const string discriminator = "discriminator";
    
    private static readonly MethodInfo? WrapInDiscriminatorFilterGenericMethod
        = typeof(MethodCallExpressionBuilder).GetMethod(nameof(MethodCallExpressionBuilder.WrapInDiscriminatorFilter));
    
    public Expression Execute(Expression expression)
    {
        expression = OptimizeGenericExpression(expression);
        
        return Visit(expression);
    }
    
    //Do we even need this? I think so
    private static Expression OptimizeGenericExpression(Expression expression)
    {
        if (WrapInDiscriminatorFilterGenericMethod == null)
        {
            throw new InvalidOperationException("WrapInDiscriminatorFilterGenericMethod is null");
        }
        
        if (expression.Type.IsGenericType)
        {
            var sourceType = expression.Type.GetGenericArguments()[0];
            var wrapInWhere = WrapInDiscriminatorFilterGenericMethod.MakeGenericMethod(sourceType);
            var wrappedExpression = wrapInWhere.Invoke(null, [expression, discriminator]);
            if (wrappedExpression != null)
            {
                expression = (Expression)wrappedExpression;
            }
        }
        else
        {
            var sourceType = expression.Type;
            var wrapInWhere = WrapInDiscriminatorFilterGenericMethod.MakeGenericMethod(sourceType);
            
            var rootMethodCallExpression = expression as MethodCallExpression;
            var source = rootMethodCallExpression!.Arguments[0];
            var discriminatorWrap = wrapInWhere.Invoke(null, [source, discriminator]);
            
            if (discriminatorWrap == null)
            {
                //Failed to wrap expression
                return expression;
            }
            
            var discriminatorWrapExpression = (MethodCallExpression)discriminatorWrap;
            
            if (rootMethodCallExpression.Arguments.Count == 1)
            {
                expression = Expression.Call(rootMethodCallExpression.Method, discriminatorWrapExpression);
            }
            else
            {
                expression = Expression.Call(rootMethodCallExpression.Method, discriminatorWrapExpression, rootMethodCallExpression.Arguments[1]);
            }
        }
        
        return expression;
    }
}