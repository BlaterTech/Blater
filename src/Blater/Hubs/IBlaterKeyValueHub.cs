using Blater.Resullts;

namespace Blater.Hubs;

public interface IBlaterKeyValueHub
{
    /// <summary>
    ///     QueryOne a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<string>> Get(string key);
    
    Task<BlaterResult<bool>> Set(string key, object value);
    
    /// <summary>
    ///     Remove a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<BlaterResult<bool>> Remove(string key);
}