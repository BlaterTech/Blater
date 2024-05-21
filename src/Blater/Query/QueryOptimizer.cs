using System.Linq.Expressions;
using System.Reflection;
using Blater.Query.Extensions;
using Blater.Query.Interfaces;

namespace Blater.Query;

public class QueryOptimizer : ExpressionVisitor, IQueryOptimizer
{
    //TODO replace this with full type name?
    private const string discriminator = "discriminator";
    
    private static readonly MethodInfo? WrapInDiscriminatorFilterGenericMethod
        = typeof(MethodCallExpressionBuilder).GetMethod(nameof(MethodCallExpressionBuilder.WrapInDiscriminatorFilter));
    
    private bool _isVisitingWhereMethodOrChild;
    
    private readonly Queue<MethodCallExpression> _nextWhereCalls;
    
    public QueryOptimizer()
    {
        _nextWhereCalls = new Queue<MethodCallExpression>();
    }
    
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
    
    
    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        if (!node.Method.IsGenericMethod)
        {
            return node;
        }
        
        if (!node.Method.IsSupportedNativelyOrByComposition())
        {
            throw new NotSupportedException($"Method {node.Method.Name} cannot be converter to a valid query.");
        }
        
        var genericDefinition = node.Method.GetGenericMethodDefinition();
        
        #region Bool member to constants
        
        if (!_isVisitingWhereMethodOrChild && genericDefinition == QueryableMethods.Where)
        {
            _isVisitingWhereMethodOrChild = true;
            var whereNode = VisitMethodCall(node);
            _isVisitingWhereMethodOrChild = false;
            
            return whereNode.IsBoolean()
                ? node.Arguments[0]
                : whereNode;
        }
        
        #endregion
        
        #region Multi-Where Optimization
        
        if (genericDefinition == QueryableMethods.Where)
        {
            if (_nextWhereCalls.Count == 0)
            {
                _nextWhereCalls.Enqueue(node);
                var tail = Visit(node.Arguments[0]);
                var currentLambda = node.GetLambda();
                var conditionExpression = Visit(currentLambda.Body);
                _nextWhereCalls.Dequeue();
                
                while (_nextWhereCalls.Count > 0)
                {
                    var nextWhereBody = _nextWhereCalls.Dequeue().GetLambdaBody();
                    conditionExpression = Expression.AndAlso(nextWhereBody, conditionExpression);
                    conditionExpression = Visit(conditionExpression);
                }
                
                if (conditionExpression.IsBoolean())
                {
                    return conditionExpression;
                }
                
                var conditionLambda = conditionExpression.WrapInLambda(currentLambda.Parameters);
                return Expression.Call(typeof(Queryable), nameof(Queryable.Where),
                                       node.Method.GetGenericArguments(), tail, conditionLambda);
            }
            
            _nextWhereCalls.Enqueue(node);
            return Visit(node.Arguments[0]);
        }
        
        #endregion
        
        #region Min/Max
        
        // Min(d => d.Property) == OrderBy(d => d.Property).Take(1).Select(d => d.Property).Min()
        if (genericDefinition == QueryableMethods.MinWithSelector)
        {
            return node
                  .SubstituteWithQueryableCall(nameof(Queryable.OrderBy))
                  .WrapInTake(1)
                  .WrapInSelect(node)
                  .WrapInMinMax(QueryableMethods.MinWithoutSelector);
        }
        
        // Max(d => d.Property) == OrderByDescending(d => d.Property).Take(1).Select(d => d.Property).Max()
        if (genericDefinition == QueryableMethods.MaxWithSelector)
        {
            return node
                  .SubstituteWithQueryableCall(nameof(Queryable.OrderByDescending))
                  .WrapInTake(1)
                  .WrapInSelect(node)
                  .WrapInMinMax(QueryableMethods.MaxWithoutSelector);
        }
        
        #endregion
        
        #region Sum/Average
        
        // Sum(d => d.Property) == Select(d => d.Property).Sum()
        if (QueryableMethods.IsSumWithSelector(genericDefinition))
        {
            return node
                  .SubstituteWithSelect(node)
                  .WrapInAverageSum(node);
        }
        
        // Average(d => d.Property) == Select(d => d.Property).Average()
        if (QueryableMethods.IsAverageWithSelector(genericDefinition))
        {
            return node
                  .SubstituteWithSelect(node)
                  .WrapInAverageSum(node);
        }
        
        #endregion
        
        #region Any/All
        
        // Any() => Take(1).Any()
        if (genericDefinition == QueryableMethods.AnyWithoutPredicate)
        {
            return node
                  .WrapInTake(1)
                  .WrapInMethodWithoutSelector(QueryableMethods.AnyWithoutPredicate);
        }
        
        // Any(d => condition) == Where(d => condition).Take(1).Any()
        if (genericDefinition == QueryableMethods.AnyWithPredicate)
        {
            return node
                  .SubstituteWithWhere(this)
                  .WrapInTake(1)
                  .WrapInMethodWithoutSelector(QueryableMethods.AnyWithoutPredicate);
        }
        
        // All(d => condition) == Where(d => !condition).Take(1).Any()
        if (genericDefinition == QueryableMethods.All)
        {
            return node
                  .SubstituteWithWhere(this, true)
                  .WrapInTake(1)
                  .WrapInMethodWithoutSelector(QueryableMethods.AnyWithoutPredicate);
        }
        
        #endregion
        
        #region Single/SingleOrDefault
        
        // Single() == Take(2).Single()
        if (genericDefinition == QueryableMethods.SingleWithoutPredicate)
        {
            return node
                  .SubstituteWithTake(2)
                  .WrapInMethodWithoutSelector(QueryableMethods.SingleWithoutPredicate);
        }
        
        // SingleOrDefault() == Take(2).SingleOrDefault()
        if (genericDefinition == QueryableMethods.SingleOrDefaultWithoutPredicate)
        {
            return node
                  .SubstituteWithTake(2)
                  .WrapInMethodWithoutSelector(QueryableMethods.SingleOrDefaultWithoutPredicate);
        }
        
        // Single(d => condition) == Where(d => condition).Take(2).Single()
        if (genericDefinition == QueryableMethods.SingleWithPredicate)
        {
            return node
                  .SubstituteWithWhere(this)
                  .WrapInTake(2)
                  .WrapInMethodWithoutSelector(QueryableMethods.SingleWithoutPredicate);
        }
        
        // SingleOrDefault(d => condition) == Where(d => condition).Take(2).SingleOrDefault()
        if (genericDefinition == QueryableMethods.SingleOrDefaultWithPredicate)
        {
            return node
                  .SubstituteWithWhere(this)
                  .WrapInTake(2)
                  .WrapInMethodWithoutSelector(QueryableMethods.SingleOrDefaultWithoutPredicate);
        }
        
        #endregion
        
        #region First/FirstOrDefault
        
        // First() == Take(1).First()
        if (genericDefinition == QueryableMethods.FirstWithoutPredicate)
        {
            return node
                  .TrySubstituteWithOptimized(nameof(Queryable.First), VisitMethodCall)
                  .SubstituteWithTake(1)
                  .WrapInMethodWithoutSelector(QueryableMethods.FirstWithoutPredicate);
        }
        
        // FirstOrDefault() == Take(1).FirstOrDefault()
        if (genericDefinition == QueryableMethods.FirstOrDefaultWithoutPredicate)
        {
            return node
                  .TrySubstituteWithOptimized(nameof(Queryable.FirstOrDefault), VisitMethodCall)
                  .SubstituteWithTake(1)
                  .WrapInMethodWithoutSelector(QueryableMethods.FirstOrDefaultWithoutPredicate);
        }
        
        // First(d => condition) == Where(d => condition).Take(1).First()
        if (genericDefinition == QueryableMethods.FirstWithPredicate)
        {
            return node
                  .SubstituteWithWhere(this)
                  .WrapInTake(1)
                  .WrapInMethodWithoutSelector(QueryableMethods.FirstWithoutPredicate);
        }
        
        // FirstOrDefault(d => condition) == Where(d => condition).Take(1).FirstOrDefault()
        if (genericDefinition == QueryableMethods.FirstOrDefaultWithPredicate)
        {
            return node
                  .SubstituteWithWhere(this)
                  .WrapInTake(1)
                  .WrapInMethodWithoutSelector(QueryableMethods.FirstOrDefaultWithoutPredicate);
        }
        
        #endregion
        
        #region Last/LastOrDefault
        
        // Last() == Last()
        if (genericDefinition == QueryableMethods.LastWithoutPredicate)
        {
            return node.TrySubstituteWithOptimized(nameof(Queryable.Last), VisitMethodCall);
        }
        
        // LastOrDefault() == LastOrDefault()
        if (genericDefinition == QueryableMethods.LastOrDefaultWithoutPredicate)
        {
            return node.TrySubstituteWithOptimized(nameof(Queryable.LastOrDefault), VisitMethodCall);
        }
        
        // Last(d => condition) == Where(d => condition).Last()
        if (genericDefinition == QueryableMethods.LastWithPredicate)
        {
            return node
                  .SubstituteWithWhere(this)
                  .WrapInMethodWithoutSelector(QueryableMethods.LastWithoutPredicate);
        }
        
        // LastOrDefault(d => condition) == Where(d => condition).LastOrDefault()
        if (genericDefinition == QueryableMethods.LastOrDefaultWithPredicate)
        {
            return node
                  .SubstituteWithWhere(this)
                  .WrapInMethodWithoutSelector(QueryableMethods.LastOrDefaultWithoutPredicate);
        }
        
        #endregion
        
        return base.VisitMethodCall(node);
    }
    
    #region Bool member to constants
    
    protected override Expression VisitBinary(BinaryExpression node)
    {
        if (node.NodeType == ExpressionType.AndAlso)
        {
            if (node.Right.IsFalse() || node.Left.IsFalse())
            {
                return Expression.Constant(false);
            }
            
            if (node.Right.IsTrue())
            {
                return Visit(node.Left);
            }
            
            if (node.Left.IsTrue())
            {
                return Visit(node.Right);
            }
        }
        
        if (node.NodeType == ExpressionType.OrElse)
        {
            if (node.Right.IsTrue() || node.Left.IsTrue())
            {
                return Expression.Constant(false);
            }
            
            if (node.Right.IsFalse())
            {
                return Visit(node.Left);
            }
            
            if (node.Left.IsFalse())
            {
                return Visit(node.Right);
            }
        }
        
        if (_isVisitingWhereMethodOrChild && node.Right is ConstantExpression c && c.Type == typeof(bool) &&
            node.NodeType is ExpressionType.Equal or ExpressionType.NotEqual)
        {
            return node;
        }
        
        return base.VisitBinary(node);
    }
    
    protected override Expression VisitMember(MemberExpression node)
    {
        if (IsWhereBooleanExpression(node))
        {
            return Expression.MakeBinary(ExpressionType.Equal, node, Expression.Constant(true));
        }
        
        return base.VisitMember(node);
    }
    
    protected override Expression VisitUnary(UnaryExpression node)
    {
        if (node is { NodeType: ExpressionType.Not, Operand: MemberExpression m } && IsWhereBooleanExpression(m))
        {
            return Expression.MakeBinary(ExpressionType.Equal, m, Expression.Constant(false));
        }
        
        return base.VisitUnary(node);
    }
    
    private bool IsWhereBooleanExpression(MemberExpression expression)
    {
        return _isVisitingWhereMethodOrChild          &&
               expression.Member is PropertyInfo info &&
               info.PropertyType == typeof(bool);
    }
    
    #endregion
}