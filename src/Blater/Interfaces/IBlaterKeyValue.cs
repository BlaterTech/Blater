using Blater.BlaterResults;

namespace Blater.Interfaces;

public interface IBlaterKeyValue
{
    /// <summary>
    ///     Get a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<TValue>> Get<TValue>(string key);
    
    /// <summary>
    ///     Get a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<string>> Get(string key);

    /// <summary>
    ///     Set a value in the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    Task<BlaterResult> Set<TValue>(string key, TValue value);

    /// <summary>
    ///     Remove a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<BlaterResult> Remove(string key);
}