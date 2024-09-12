using System.Buffers;
using System.Text;

namespace Blater.Extensions;

public static partial class EncodingExtensions
{
    public static string ToBase64(this string str)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
    }

    public static string ToBase64(this in Span<byte> span)
    {
        return Convert.ToBase64String(span);
    }

    public static string ToBase64(this ReadOnlyMemory<byte> bytes)
    {
        return Convert.ToBase64String(bytes.Span);
    }

    public static string ToBase64(this Memory<byte> bytes)
    {
        return Convert.ToBase64String(bytes.Span);
    }

    public static string ToBase64(this ReadOnlySequence<byte> bytes)
    {
        return Convert.ToBase64String(bytes.ToArray());
    }

    public static string FromBase64ToString(this string toDecode)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(toDecode));
    }
}