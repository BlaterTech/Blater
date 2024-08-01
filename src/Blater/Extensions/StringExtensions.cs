namespace Blater.Extensions;

public static partial class StringExtensions
{
    public static bool ComparedTo(this string str, string with)
    {
        return string.Equals(str, with, StringComparison.OrdinalIgnoreCase);
    }


}