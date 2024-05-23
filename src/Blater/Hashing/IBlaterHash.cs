namespace Blater.Hashing;

public interface IBlaterHash
{
    Task<string> ComputeHash(string content);
    
    Task<string> ComputeHash(byte[] content);
    
    Task<string> ComputeHash(Stream content);
}