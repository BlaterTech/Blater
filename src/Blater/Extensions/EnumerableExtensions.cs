namespace Blater.Extensions;

public static class EnumerableExtensions
{
    public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> enumerable) => enumerable.ToList().AsReadOnly();
}