using System.Linq.Expressions;
using System.Reflection;

namespace Blater.Query
{
    internal static class MethodCallExpressionBuilder
    {
        #region Substitute
        
        public static MethodCallExpression TrySubstituteWithOptimized(this MethodCallExpression node, string methodName, Func<MethodCallExpression, Expression> visitMethod)
        {
            if (node.Arguments.Count <= 0 || node.Arguments[0] is not MethodCallExpression methodCallExpression)
            {
                return node;
            }
            
            var optimizedArgument = visitMethod(methodCallExpression);
            node = Expression.Call(typeof(Queryable), methodName,
                                   node.Method.GetGenericArguments(), optimizedArgument);
            
            return node;
        }
        
        public static MethodCallExpression SubstituteWithQueryableCall(this MethodCallExpression node, string methodName)
        {
            return Expression.Call(typeof(Queryable), methodName, node.Method.GetGenericArguments(), node.Arguments[0], node.Arguments[1]);
        }
        
        public static MethodCallExpression SubstituteWithTake(this MethodCallExpression node, int numberOfElements)
        {
            return Expression.Call(typeof(Queryable), nameof(Queryable.Take),
                                   node.Method.GetGenericArguments().Take(1).ToArray(), node.Arguments[0], Expression.Constant(numberOfElements));
        }
        
        public static MethodCallExpression SubstituteWithSelect(this MethodCallExpression node, MethodCallExpression selectorNode)
        {
            var selectorType = selectorNode.GetSelectorType();
            var genericArgumentTypes = node.Method
                                           .GetGenericArguments()
                                           .Append(selectorType)
                                           .ToArray();
            
            return Expression.Call(typeof(Queryable), nameof(Queryable.Select), genericArgumentTypes, node.Arguments[0], selectorNode.Arguments[1]);
        }
        
        public static MethodCallExpression SubstituteWithWhere(this MethodCallExpression node, ExpressionVisitor optimizer, bool negate = false)
        {
            var predicate = node.Arguments[1];
            
            if (negate)
            {
                var lambdaExpression = node.GetLambda();
                var body = Expression.Not(lambdaExpression.Body);
                predicate = body.WrapInLambda(lambdaExpression.Parameters);
            }
            
            var e = Expression.Call(typeof(Queryable), nameof(Queryable.Where), node.Method.GetGenericArguments(), node.Arguments[0], predicate);
            return (MethodCallExpression)optimizer.Visit(e);
        }
        
        #endregion
        
        #region Wrap
        
        public static MethodCallExpression WrapInTake(this MethodCallExpression node, int numberOfElements)
        {
            return Expression.Call(typeof(Queryable), nameof(Queryable.Take),
                                   node.Method.GetGenericArguments().Take(1).ToArray(), node, Expression.Constant(numberOfElements));
        }
        
        public static MethodCallExpression WrapInSelect(this MethodCallExpression node, MethodCallExpression selectorNode)
        {
            var selectorType = selectorNode.GetSelectorType();
            var genericArgumentTypes = node.Method
                                           .GetGenericArguments()
                                           .Append(selectorType)
                                           .ToArray();
            
            return Expression.Call(typeof(Queryable), nameof(Queryable.Select), genericArgumentTypes, node, selectorNode.Arguments[1]);
        }
        
        public static MethodCallExpression WrapInAverageSum(this MethodCallExpression node, MethodCallExpression wrap)
        {
            var selectorType = wrap.GetSelectorType();
            var queryableType = typeof(IQueryable<>).MakeGenericType(selectorType);
            var numberMethod = typeof(Queryable).GetMethod(wrap.Method.Name, [queryableType]);
            if (numberMethod == null)
            {
                throw new InvalidOperationException($"Method {wrap.Method.Name} not found in {nameof(Queryable)}.");
            }
            
            return Expression.Call(numberMethod, node);
        }
        
        public static MethodCallExpression WrapInMinMax(this MethodCallExpression node, MethodInfo methodInfo)
        {
            var genericMethodInfo = methodInfo.MakeGenericMethod(node.Method.GetGenericArguments()[1]);
            return Expression.Call(genericMethodInfo, node);
        }
        
        public static MethodCallExpression WrapInMethodWithoutSelector(this MethodCallExpression node, MethodInfo methodInfo)
        {
            var genericMethodInfo = methodInfo.MakeGenericMethod(node.Method.GetGenericArguments()[0]);
            return Expression.Call(genericMethodInfo, node);
        }
        
        //TODO maybe use this to determine the type of the model?
        public static MethodCallExpression WrapInDiscriminatorFilter<TSource>(this Expression node, string fullTypeName)
            where TSource : BaseDataModel
        {
            Expression<Func<TSource, bool>> filter = d => d.FullTypeName == fullTypeName;
        
            return Expression.Call(typeof(Queryable), nameof(Queryable.Where),
                new[] { typeof(TSource) }, node, filter);
        }
        
        #endregion
    }
}