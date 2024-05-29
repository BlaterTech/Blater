using Blater.Query.Models;
using Blater.Resullts;

namespace Blater.Interfaces;

public interface IBlaterDatabaseStore
{
    /// <summary>
    /// Finds a single document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BlaterResult<string>> FindOne(BlaterId id);
    
    /// <summary>
    /// Finds a single document using query.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<string>> FindOne(BlaterQuery query);
    
    /// <summary>
    /// Finds a single document using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<string>> FindOne(string partition, BlaterQuery query);

    /// <summary>
    /// Finds many documents using query
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<IEnumerable<string>>> FindMany(BlaterQuery query);
    
    /// <summary>
    /// Finds many documents using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<IEnumerable<string>>> FindMany(string partition, BlaterQuery query);

    /// <summary>
    /// Returns the same document but with the new revision
    /// </summary>
    /// <param name="id"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    public Task<BlaterResult<string>> Upsert(BlaterId id, string json);

    public Task<BlaterResult?> DeleteOne(BlaterId id);

    /// <summary>
    /// Gets the count of all documents inside the database
    /// </summary>
    /// <returns></returns>
    public Task<BlaterResult<int>> Count();
    
    /// <summary>
    /// Gets the count of all documents inside the database by partition
    /// </summary>
    /// <param name="partition"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> Count(string partition);
    
    
    /// <summary>
    /// Gets the count of all documents inside the database by query
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> Count(string partition, BlaterQuery query);
}