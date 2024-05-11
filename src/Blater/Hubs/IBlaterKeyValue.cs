namespace Blater.Hubs;

public interface IBlaterKeyValueHub
{
    Task<BlaterResult<string>> GetKeyValue(string key);
    
    Task<BlaterResult> SetKeyValue(string key, string json);
    
    Task<BlaterResult> RemoveKeyValue(string key);
}