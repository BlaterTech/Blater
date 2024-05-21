namespace Blater.Query.Extensions;

public static class EnumerableQueryExtensions
{
    public static bool Contains<T>(this IEnumerable<T> source, IEnumerable<T> input)
    {
        return input.All(source.Contains);
    }
}