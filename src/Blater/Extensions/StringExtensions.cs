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
                   ;
    }

}