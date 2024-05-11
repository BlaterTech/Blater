namespace Blater.Interfaces;

public interface IBlaterCache
{
    
    Task Remove(string key);
}