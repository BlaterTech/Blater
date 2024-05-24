using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers.BinaryHandlers;

public class AndOrVisitorHandler : HandlerBase<BinaryExpression>
{
    public override void Handle(BinaryExpression expression, VisitorContext? context)
    {
        if (context == null)
        {
            return;
        }
        
        var isAnd = expression.NodeType is ExpressionType.AndAlso or ExpressionType.And;
        
        context.Visit(expression.Left);
        context.Visit(expression.Right);
        
        var right = context.GetResult();
        var left = context.GetResult();
        
        var @operator = isAnd
            ? "$and"
            : "$or";
        
        var query = new DynamicDictionary { { @operator, new List<IDictionary<string, object>?> { left, right } } };
        
        context.SetResult(query);
    }
    
    public override bool CanHandle(BinaryExpression expression)
    {
        var isAnd = expression.NodeType is ExpressionType.AndAlso or ExpressionType.And;
        var isOr = expression.NodeType is ExpressionType.OrElse or ExpressionType.Or;
        
        var supported = isAnd || isOr;
        
        return supported;
    }
}