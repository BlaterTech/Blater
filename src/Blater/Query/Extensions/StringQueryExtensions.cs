using System.Text.RegularExpressions;

namespace Blater.Query.Extensions;

public static class StringQueryExtensions
{
    public static bool IsMatch(this string input, string pattern)
    {
        return new Regex(pattern).IsMatch(input);
    }
}