using System.Linq.Expressions;
using Blater.BlaterResults;
using Blater.Models.Pagination;

namespace Blater.Interfaces;

public interface IBlaterDatabaseRepository<T>
{
    public Task<BlaterResult<T>> FindOne(Guid id);
    public Task<BlaterResult<T>> FindOne(Expression<Func<T, bool>> predicate);
    public Task<BlaterResult<IReadOnlyList<T>>> FindMany(Expression<Func<T, bool>> predicate);

    public Task<BlaterResult> Upsert(T entity);

    public Task<BlaterResult?> DeleteOne(Guid id);
    public Task<BlaterResult<int>> DeleteMany(Expression<Func<T, bool>> predicate);

    public Task<BlaterResult<int>> Count();
    public Task<BlaterResult<int>> Count(Expression<Func<T, bool>> predicate);

    public Task<BlaterResult<PaginationResponse<T>>> GetPage(PaginationRequest<T> request);
}