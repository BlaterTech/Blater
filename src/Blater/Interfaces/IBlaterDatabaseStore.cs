using Blater.Query.Models;
using Blater.Resullts;

namespace Blater.Interfaces;

public interface IBlaterDatabaseStore
{
    #region FindOne
    
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
    
    #endregion
    
    #region FindMany
    
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
    
    #endregion
    
    
    #region Update/Insert/Upsert
    
    /// <summary>
    /// Upserts a document, it replaces the document if it exists
    /// </summary>
    /// <param name="id"></param>
    /// <param name="json"></param>
    /// <returns>Returns the same document but with the new revision</returns>
    public Task<BlaterResult<string>> Upsert(BlaterId id, string json);
    
    /// <summary>
    /// Updates a document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="json"></param>
    /// <returns>Returns true if the document was updated</returns>
    public Task<BlaterResult<bool>> Update(BlaterId id, string json);
    
    /// <summary>
    /// Updates a document by its id and query
    /// </summary>
    /// <param name="id"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    public Task<BlaterResult<bool>> Insert(BlaterId id, string json);
    
    #endregion
    
    #region Delete
    
    /// <summary>
    /// Deletes a document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BlaterResult?> Delete(BlaterId id);
    
    /// <summary>
    /// Deletes a document by its ids
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public Task<BlaterResult?> Delete(List<BlaterId> ids);
    
    /// <summary>
    /// Deletes a document by its query
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public Task<BlaterResult?> Delete(BlaterQuery query);
    
    #endregion
    
    #region Count
    
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