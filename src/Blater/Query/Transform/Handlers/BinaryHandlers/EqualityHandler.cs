using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers.BinaryHandlers;

public class EqualityHandler : BinaryHandler
{
    public override void Handle(BinaryExpression expression, VisitorContext? context)
    {
        if (context == null)
        {
            return;
        }
        
        var nameValue = GetNameValue(expression);
        var @operator = expression.NodeType == ExpressionType.Equal
            ? "$eq"
            : "$ne";
        
        var equal = new DynamicDictionary
        {
            { @operator, nameValue.Constant?.Value }
        };
        var result = CreateQuery(nameValue.Member, equal, context);
        
        context.SetResult(result);
    }
    
    public override bool CanHandle(BinaryExpression expression)
    {
        var isBoolean = expression.NodeType is ExpressionType.Equal or ExpressionType.NotEqual;
        
        return isBoolean;
        //return isBoolean && expression.Left is MemberExpression;
    }
}