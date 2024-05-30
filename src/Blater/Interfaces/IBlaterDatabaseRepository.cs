using Blater.Resullts;

using System.Linq.Expressions;
using Blater.Query.Interfaces;

namespace Blater.Interfaces;

public interface IBlaterDatabaseRepository<T> where T : BaseDataModel
{
    #region FindOne
    
    /// <summary>
    /// Finds a single document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BlaterResult<T>> FindOne(BlaterId id);
    
    /// <summary>
    /// Finds a single document using query.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<BlaterResult<T>> FindOne(Expression<Func<T, bool>> predicate);
    
    /// <summary>
    /// Finds many documents using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<BlaterResult<T>> FindOne(string partition, Expression<Func<T, bool>> predicate);
    
    #endregion
    
    #region FindMany
    
    /// <summary>
    /// Finds many documents using query
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<BlaterResult<IReadOnlyList<T>>> FindMany(Expression<Func<T, bool>> predicate);
    
    /// <summary>
    /// Finds many documents using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<BlaterResult<IReadOnlyList<T>>> FindMany(string partition, Expression<Func<T, bool>> predicate);
    
    #endregion
    
    #region Insert
    /// <summary>
    /// Upserts a document, it replaces the document if it exists
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Returns the same entity but with the revision</returns>
    public Task<BlaterResult<T>> Upsert(T entity);
    
    /// <summary>
    /// Inserts a document, it fails if the document already exists
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<BlaterResult<T>> Insert(T entity);
    
    /// <summary>
    /// Updates a document, it fails if the document does not exist
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<BlaterResult<T>> Update(T entity);
    #endregion
    
    #region Delete
    
    /// <summary>
    /// Deletes a document
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Task<BlaterResult> Delete(T obj);
    
    /// <summary>
    /// Deletes a document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<BlaterResult> Delete(BlaterId id);
    
    /// <summary>
    /// Deletes many documents using a query
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> DeleteMany(Expression<Func<T, bool>> predicate);
    
    /// <summary>
    /// Deletes many documents using a query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> DeleteMany(string partition, Expression<Func<T, bool>> predicate);
    
    #endregion
    
    #region Count
    
    /// <summary>
    /// Counts all documents
    /// </summary>
    /// <returns></returns>
    public Task<BlaterResult<int>> Count();
    
    /// <summary>
    /// Counts all documents by partition
    /// </summary>
    /// <param name="partition"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> Count(string partition);
    
    /// <summary>
    /// Counts all documents by query
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> Count(Expression<Func<T, bool>> predicate);
    
    /// <summary>
    /// Counts all documents by partition and query
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<BlaterResult<int>> Count(string partition, Expression<Func<T, bool>> predicate);
    
    #endregion
    
    public IBlaterQueryable<T> Queryable { get; }
}