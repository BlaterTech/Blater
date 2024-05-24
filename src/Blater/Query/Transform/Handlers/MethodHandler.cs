using System.Linq.Expressions;

namespace Blater.Query.Transform.Handlers;

public abstract class MethodHandler : HandlerBase<MethodCallExpression>
{
    protected static Type? GetDeclaringType(MethodCallExpression expression)
    {
        var method = expression.Method;
        return method.DeclaringType;
    }
    
    protected static string GetMethodName(MethodCallExpression expression)
    {
        var method = expression.Method;
        return method.Name;
    }
}