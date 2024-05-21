using System.Linq.Expressions;

namespace Blater.Query.Extensions;

internal static class ExpressionExtensions
{
    public static bool IsTrue(this Expression expression)
    {
        return expression is ConstantExpression { Value: true };
    }
    
    public static bool IsFalse(this Expression expression)
    {
        return expression is ConstantExpression { Value: false };
    }
    
    public static bool IsBoolean(this Expression expression)
    {
        return expression is ConstantExpression { Value: bool };
    }
}