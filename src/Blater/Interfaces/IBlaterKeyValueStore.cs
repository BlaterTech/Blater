using Blater.Resullts;

namespace Blater.Interfaces;

public interface IBlaterKeyValueStore
{
    /// <summary>
    ///     QueryOne a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<TValue>> Get<TValue>(string key) where TValue : BaseDataModel;

    /// <summary>
    ///     QueryOne a value from the key value store
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
    Task<BlaterResult<bool>> Set<TValue>(string key, TValue value) where TValue : BaseDataModel;
    
    Task<BlaterResult<bool>> Set(string key, object value);

    /// <summary>
    ///     Remove a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<BlaterResult<bool>> Remove(string key);
}