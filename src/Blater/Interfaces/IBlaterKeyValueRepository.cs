namespace Blater.Interfaces;

public interface IBlaterKeyValueRepository
{
    //TODO
    //public string? Partition { get; set; }

    /// <summary>
    ///     QueryOne a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns>Returns null if not found</returns>
    Task<TValue> Get<TValue>(string key);

    /// <summary>
    ///     QueryOne a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <returns>Returns null if not found</returns>
    Task<string> Get(string key);

    /// <summary>
    /// All keys
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<string>> Get();

    /// <summary>
    ///     Set a value in the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    Task<bool> Set<TValue>(string key, TValue value);

    Task<bool> Set(string key, object value);

    /// <summary>
    ///     Remove a value from the key value store
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<bool> Remove(string key);
}