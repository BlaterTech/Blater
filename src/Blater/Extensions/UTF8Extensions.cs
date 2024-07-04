using System.Text;

namespace Blater.Extensions;

public static class Utf8Extensions
{
    public static string FromUtf8(this byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }

    public static string FromUtf8(this ReadOnlyMemory<byte> bytes)
    {
        return Encoding.UTF8.GetString(bytes.Span);
    }

    public static byte[] ToUtf8(this string str)
    {
        return Encoding.UTF8.GetBytes(str);
    }
}