using Blater.Query.Interfaces;
using System.Linq.Expressions;

namespace Blater.Interfaces;

/// <summary>
/// This the highest abstraction of the database
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBlaterDatabaseRepository<T> where T : BaseDataModel
{
    #region FindOnes

    /// <summary>
    /// Finds a single document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<T?> FindOne(BlaterId id);

    /// <summary>
    /// Finds a single document using query.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<T?> FindOne(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Finds many documents using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<T?> FindOne(string partition, Expression<Func<T, bool>> predicate);

    #endregion

    #region Query

    /// <summary>
    /// Finds many documents using query
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<IReadOnlyList<T?>> FindMany(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Finds many documents using query and partition
    /// </summary>
    /// <param name="partition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<IReadOnlyList<T?>> FindMany(string partition, Expression<Func<T, bool>> predicate);

    #endregion

    #region Insert
    /// <summary>
    /// Upserts a document, it replaces the document if it exists
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Returns the same entity but with the revision</returns>
    public Task<bool> Upsert(T entity);

    /// <summary>
    /// Inserts a document, it fails if the document already exists
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<bool> Insert(T entity);

    /// <summary>
    /// Updates a document, it fails if the document does not exist
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<bool> Update(T entity);
    #endregion

    #region Deletes


    public Task<bool> Delete(T entity);

    /// <summary>
    /// Deletes a document by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> Delete(BlaterId id);

    /// <summary>
    /// Deletes many documents using a query
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<int> DeleteMany(Expression<Func<T, bool>> predicate);

    #endregion

    #region Counts

    /// <summary>
    /// Counts all documents
    /// </summary>
    /// <returns></returns>
    public Task<int> Count();

    /// <summary>
    /// Counts all documents by partition
    /// </summary>
    /// <param name="partition"></param>
    /// <returns></returns>
    public Task<int> Count(string partition);

    /// <summary>
    /// Counts all documents by query
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Task<int> Count(Expression<Func<T, bool>> predicate);

    #endregion

    public IBlaterQueryable<T> Queryable { get; }
}