using System.Linq.Expressions;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.Interfaces;

public interface IBlaterDatabaseStoreT<T>
{
    #region FindOnes

    /// <summary>
    /// Finds a single document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BlaterResult<T>> FindOne(BlaterId id);

    /// <summary>
    /// Finds a single document using query.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<T>> FindOne(BlaterQuery query);
    
    public Task<BlaterResult<T>> FindOne(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Finds a single document using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<T>> FindOne(string partition, BlaterQuery query);

    #endregion

    #region Query

    /// <summary>
    /// Finds many documents using query
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<IReadOnlyList<T>>> FindMany(BlaterQuery query);

    /// <summary>
    /// Finds many documents using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<IReadOnlyList<T>>> FindMany(string partition, BlaterQuery query);
    
    public Task<BlaterResult<IReadOnlyList<T>>> FindMany(Expression<Func<T, bool>> predicate);

    #endregion

    #region Update/Insert/Upserts
    
    /// <summary>
    /// Upserts a document, it replaces the document if it exists
    /// </summary>
    /// <param name="id"></param>
    /// <param name="obj"></param>
    /// <returns>Returns the same document but with the new revision</returns>
    public Task<BlaterResult<bool>> Upsert(BlaterId id, T obj);
    
    /// <summary>
    /// Updates a document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="obj"></param>
    /// <returns>Returns true if the document was updated</returns>
    public Task<BlaterResult<bool>> Update(BlaterId id, T obj);
    
    /// <summary>
    /// Updates a document by its id and query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Task<BlaterResult<bool>> Insert(BlaterId id, T obj);

    #endregion
    
    #region Changes

    IAsyncEnumerable<BlaterResult<string>> GetChanges();
    IAsyncEnumerable<BlaterResult<string>> GetChangesQuery(BlaterQuery query);

    #endregion

    #region Deletes

    /// <summary>
    /// Deletes a document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BlaterResult<bool>> Delete(BlaterId id);

    /// <summary>
    /// Deletes a document by its ids
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> Delete(List<BlaterId> ids);

    /// <summary>
    /// Deletes a document by its query
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> Delete(BlaterQuery query);

    #endregion

    #region Counts

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

    #endregion
}