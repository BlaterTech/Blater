/*using Blater.Results;

namespace Blater.Interfaces;

/// <summary>
/// Lower level implementation of the Blater database store, used by the repository
/// You can use this to get the raw data from the database without any processing or validation
/// </summary>
public interface IBlaterDatabaseStore
{
    /// <summary>
    /// Finds a single document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Returns the JSON object in string format</returns>
    public Task<BlaterResult<string>> Get(Ulid id);


    /// <summary>
    /// Finds a single document using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="query"></param>
    /// <returns>Returns the JSON object in string format</returns>
    public Task<BlaterResult<string>> QueryOne(string partition, BlaterQuery query);

    /// <summary>
    /// Finds many documents using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="query"></param>
    /// <returns>Returns the JSON object in string format</returns>
    public Task<BlaterResult<IReadOnlyList<string>>> Query(string partition, BlaterQuery query);

    #region Changes

    /// <summary>
    /// 
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="query"></param>
    /// <returns>Returns the JSON object in string format</returns>
    IAsyncEnumerable<BlaterResult<string>> WatchChangesQuery(string partition, BlaterQuery query, CancellationToken cancellationToken);

    #endregion

    #region Update/Insert/Upserts

    /// <summary>
    /// Upserts a document, it replaces the document if it exists
    /// </summary>
    /// <param name="id"></param>
    /// <param name="json"></param>
    /// <returns>Returns the same document but with the new revision</returns>
    public Task<BlaterResult<Ulid>> Upsert(Ulid id, string json);

    /// <summary>
    /// Updates a document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="json"></param>
    /// <returns>Returns true if the document was updated</returns>
    public Task<BlaterResult<Ulid>> Update(Ulid id, string json);

    /// <summary>
    /// Updates a document by its id and query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    public Task<BlaterResult<Ulid>> Insert(Ulid id, string json);

    #endregion

    #region Deletes

    /// <summary>
    /// Deletes a document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BlaterResult<bool>> Delete(Ulid id);

    /// <summary>
    /// Deletes a document by its ids
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> Delete(List<Ulid> ids);

    /// <summary>
    /// Deletes a document by its query
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> Delete(BlaterQuery query);

    #endregion

    #region Counts

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

    #endregion
}*/