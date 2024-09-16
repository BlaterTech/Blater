using System.Buffers;
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

    public static string FromUtf8(this ReadOnlySequence<byte> bytes)
    {
        return Encoding.UTF8.GetString(bytes.ToArray());
    }

    public static string FromUtf8(this in Span<byte> span)
    {
        return Encoding.UTF8.GetString(span);
    }

    public static Memory<byte> ToUtf8(this string str)
    {
        return Encoding.UTF8.GetBytes(str);
    }

    public static Span<byte> ToUtf8Span(this string str)
    {
        return Encoding.UTF8.GetBytes(str);
    }
}