using System.Collections.Generic;
using System.Linq;

namespace Blater.Extensions;

public static class EnumerableExtensions
{
    public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> enumerable)
    {
        return enumerable.ToList().AsReadOnly();
    }
}