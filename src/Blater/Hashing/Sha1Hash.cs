using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Blater.Hashing;

[SuppressMessage("Security", "CA5350:Do Not Use Weak Cryptographic Algorithms")]
public class Sha1Hash : IBlaterHash
{
    public async Task<string> ComputeHash(string content)
    {
        return await Task.Run(() =>
        {
            var data = Encoding.UTF8.GetBytes(content);
            data = SHA1.HashData(data);
            return Convert.ToHexString(data);
        });
    }
    
    public async Task<string> ComputeHash(byte[] content)
    {
        return await Task.Run(() =>
        {
            var data = SHA1.HashData(content);
            return Convert.ToHexString(data);
        });
    }
    
    public async Task<string> ComputeHash(Stream content)
    {
        return await Task.Run(() =>
        {
            var data = SHA1.HashData(content);
            return Convert.ToHexString(data);
        });
    }
}