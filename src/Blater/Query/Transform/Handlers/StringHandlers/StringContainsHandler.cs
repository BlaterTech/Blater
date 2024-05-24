using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers.StringHandlers;

[SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity")]
public class StringContainsHandler : MethodHandler
{
    public override void Handle(MethodCallExpression expression, VisitorContext? context)
    {
        if (expression.Arguments[0] is not ConstantExpression cValue)
        {
            throw new NotSupportedException("requires a parameter");
        }
        
        //var name = GetMemberName((MemberExpression)expression.Object, context);
        
        if (cValue.Value == null)
        {
            return;
        }
        
        var regex = new DynamicDictionary { { "$regex", cValue.Value } };
        var query = CreateQuery(expression.Object, regex, context);
        
        context?.SetResult(query);
    }
    
    public override bool CanHandle(MethodCallExpression expression)
    {
        var isString = GetDeclaringType(expression) == typeof(string);
        var isMethod = GetMethodName(expression).Equals("Contains", StringComparison.Ordinal);
        
        return isString && isMethod;
    }
}