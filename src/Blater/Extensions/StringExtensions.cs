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
                  .Replace("?", "_", StringComparison.OrdinalIgnoreCase)
                   ;
    }
    
    public static Task<string> ToBase64(this string str)
    {
        return Task.Run<string>(() => Convert.ToBase64String(Encoding.UTF8.GetBytes(str)));
    }

}