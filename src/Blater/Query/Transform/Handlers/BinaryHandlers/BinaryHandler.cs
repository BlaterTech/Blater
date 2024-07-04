using System.Linq.Expressions;

namespace Blater.Query.Transform.Handlers.BinaryHandlers;

public abstract class BinaryHandler : HandlerBase<BinaryExpression>
{
    public static NameValue GetNameValue(BinaryExpression expression)
    {
        var nameValueExp = new MemberNameEvaluator();
        nameValueExp.Visit(expression);

        return new NameValue
        {
            Member = nameValueExp.Property,
            Constant = nameValueExp.Value
        };
    }
}