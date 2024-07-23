using System;
using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers.StringHandlers;

public class StringEndsWithHandler : MethodHandler
{
    public override void Handle(MethodCallExpression expression, VisitorContext? context)
    {
        if (expression.Arguments[0] is not ConstantExpression cValue)
        {
            throw new NotSupportedException("requires a parameter");
        }

        //var name = GetMemberName((MemberExpression)expression.Object, context);

        var regex = new DynamicDictionary { { "$regex", $"{cValue.Value}$" } };
        var query = CreateQuery(expression.Object, regex, context);

        context?.SetResult(query);
    }

    public override bool CanHandle(MethodCallExpression expression)
    {
        var isString = GetDeclaringType(expression) == typeof(string);
        var isMethod = GetMethodName(expression).Equals("EndsWith", StringComparison.OrdinalIgnoreCase);

        return isString && isMethod;
    }
}