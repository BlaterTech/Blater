namespace Blater.Extensions;

public static partial class StringExtensions
{
    public static bool ComparedTo(this string str, string with)
    {
        return string.Equals(str, with, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsEmpty(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
    
    public static bool StartsWithAny(this string value, IEnumerable<string> strings)
    {
        return strings.Any(value.StartsWith);
    }
}