using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers;

public class NotHandler : HandlerBase<UnaryExpression>
{
    public override void Handle(UnaryExpression expression, VisitorContext? context)
    {
        if (context == null)
        {
            return;
        }
        
        context.Visit(expression.Operand);
        var val = context.GetResult();
        
        var result = new DynamicDictionary();
        if (val != null)
        {
            result.Add("$not", val);
        }
        
        context.SetResult(result);
    }
    
    public override bool CanHandle(UnaryExpression expression)
    {
        return expression.NodeType == ExpressionType.Not;
    }
}