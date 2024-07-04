using System.Collections;
using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers.InNotInHandlers;

/// <summary>
/// support the $in syntax IE the name is in ["dave", "chan"]
/// </summary>
/// <example>
/// <code>
/// session.Query<Person>(person => new []{"dave","chan"}.Any(name => name == person.Name));
/// </code>
/// </example>
public class InHandler : HandlerBase<MethodCallExpression>
{
    public override void Handle(MethodCallExpression expression, VisitorContext? context)
    {
        if (context == null)
        {
            return;
        }

        var list = (IEnumerable)((ConstantExpression)expression.Arguments[0]).Value!;
        var binaryExp = (BinaryExpression)((LambdaExpression)expression.Arguments[1]).Body;
        var property = binaryExp.Right as MemberExpression ?? (MemberExpression)binaryExp.Left;

        var inQuery = new DynamicDictionary { { "$in", list } };
        var query = CreateQuery(property, inQuery, context);

        context.SetResult(query);
    }

    public override bool CanHandle(MethodCallExpression expression)
    {
        if (expression.Method.Name != "Any")
        {
            return false;
        }

        if (expression.Arguments[0] is not ConstantExpression val0 || expression.Arguments[1] is not LambdaExpression val1)
        {
            return false;
        }

        if (val1.Body is not BinaryExpression { NodeType: ExpressionType.Equal })
        {
            return false;
        }

        var list = val0.Value as IEnumerable;

        return list != null;
    }
}