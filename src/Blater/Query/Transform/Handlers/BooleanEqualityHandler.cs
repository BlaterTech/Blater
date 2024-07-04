using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers;

public class BooleanEqualityHandler : HandlerBase<UnaryExpression>
{
    public override bool CanHandle(UnaryExpression expression)
    {
        //note we are looking to exit from this as quick as possible.
        //must be a lambda which returns true and has a memberExpression for a body.
        var isQuote = expression.NodeType == ExpressionType.Quote;
        if (!isQuote)
        {
            return false;
        }

        if (expression.Operand is not LambdaExpression lambda)
        {
            return false;
        }

        var isBoolReturn = lambda.ReturnType == typeof(bool);
        if (!isBoolReturn)
        {
            return false;
        }

        var memberExpression = lambda.Body as MemberExpression;
        return memberExpression != null;
    }

    public override void Handle(UnaryExpression expression, VisitorContext? context)
    {
        if (context == null)
        {
            return;
        }

        var memberExpression = (MemberExpression)((LambdaExpression)expression.Operand).Body;

        var name = memberExpression.Member.Name;

        var equal = new DynamicDictionary { { "$eq", true } };
        var result = new DynamicDictionary { { name, equal } };

        context.SetResult(result);
    }
}