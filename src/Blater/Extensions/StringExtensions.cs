using System.Text;

namespace Blater.Extensions;

public static class StringExtensions
{
    public static bool ComparedTo(this string str, string with) => string.Equals(str, with, StringComparison.OrdinalIgnoreCase);
    
    public static string SanitizeString(this string str)
    {
        return str.ToLower()
                  .Replace(" ", "_", StringComparison.OrdinalIgnoreCase)
                  .Replace("+", "_", StringComparison.OrdinalIgnoreCase)
                  .Replace(".", "_", StringComparison.OrdinalIgnoreCase)
                  .Replace("\\", "_", StringComparison.OrdinalIgnoreCase)
                  .Replace("//", "_", StringComparison.OrdinalIgnoreCase)
                  .Replace("?", "_", StringComparison.OrdinalIgnoreCase);
    }
    
    public static Task<string> ToBase64(this string str)
    {
        return Task.Run(() => Convert.ToBase64String(Encoding.UTF8.GetBytes(str)));
    }
    
    public static Task<string> FromBase64ToString(this string toDecode)
    {
        return Task.Run((Func<string>) (() => Encoding.UTF8.GetString(Convert.FromBase64String(toDecode))));
    }
    
    public static string ToCamelCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
        
        return char.ToLowerInvariant(str[0]) + str[1..];
    }
    
    public static Span<char> ToCamelCase(this Span<char> str)
    {
        if (str.Length == 0)
        {
            return str;
        }
        
        str[0] = char.ToLowerInvariant(str[0]);
        return str;
    }

    public static BlaterId ToBlaterId(this string value)
    {
        var parts = value.Split(':');

        return parts.Length != 2
            ? throw new FormatException("The value is not in the correct format")
            : new BlaterId(parts[0], Guid.Parse(parts[1]));
    }
}