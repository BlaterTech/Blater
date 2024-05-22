using System.Linq.Expressions;

namespace Blater.Query.Extensions;

public static class QueryExtensions
{
    public static bool In<T>(this List<T> list, params T[] values)
    {
        return true;
    }
    
    public static bool Regex(this string value, string pattern)
    {
        return true;
    }
}