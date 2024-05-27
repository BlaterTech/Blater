namespace Blater.Query.Extensions;

public static class BlaterQueryExtensions
{
    public static bool In<TSource>(this IEnumerable<TSource> source, params TSource[] values)
    {
        return source.Any(values.Contains);
    }
    
    public static bool Regex<TSource>(this IEnumerable<TSource> source, string regex)
    {
        return source.Any(s => System.Text.RegularExpressions.Regex.IsMatch(s?.ToString() ?? throw new InvalidOperationException(), regex));
    }
}