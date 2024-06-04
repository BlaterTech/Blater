using System.Text;

namespace Blater.Extensions;

public static class UTF8Extensions
{
    public static string FromUTF8(this byte[] bytes) => Encoding.UTF8.GetString(bytes);
    
    public static string FromUTF8(this ReadOnlyMemory<byte> bytes)
    {
        return Encoding.UTF8.GetString(bytes.Span);
    }
    
    public static byte[] ToUTF8(this string str) => Encoding.UTF8.GetBytes(str);
}