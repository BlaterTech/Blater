using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers.BinaryHandlers;

public class LessAndGreaterThanHandler : BinaryHandler
{
    public override void Handle(BinaryExpression expression, VisitorContext? context)
    {
        if (context == null)
        {
            return;
        }
        
        var @operator = expression.NodeType switch
        {
            ExpressionType.LessThan           => "$lt",
            ExpressionType.LessThanOrEqual    => "$lte",
            ExpressionType.GreaterThan        => "$gt",
            ExpressionType.GreaterThanOrEqual => "$gte",
            _                                 => null
        };
        
        var nameValue = GetNameValue(expression);
        //var name = GetMemberName(nameValue.Member, context);
        
        if (@operator == null)
        {
            return;
        }
        
        var compareObject = new DynamicDictionary
        {
            {
                @operator,
                nameValue.Constant?.Value
            }
        };
        var result = CreateQuery(nameValue.Member, compareObject, context);
        
        context.SetResult(result);
    }
    
    
    public override bool CanHandle(BinaryExpression expression)
    {
        var isLessThan = expression.NodeType           == ExpressionType.LessThan;
        var isLessThanOrEqual = expression.NodeType    == ExpressionType.LessThanOrEqual;
        var isGreaterThan = expression.NodeType        == ExpressionType.GreaterThan;
        var isGreaterThanOrEqual = expression.NodeType == ExpressionType.GreaterThanOrEqual;
        
        var supported = isLessThan || isLessThanOrEqual || isGreaterThan || isGreaterThanOrEqual;
        
        return supported;
    }
}