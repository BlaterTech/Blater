using Blater.Models.Pagination;
using Blater.Resullts;

using System.Linq.Expressions;

namespace Blater.Interfaces;

public interface IBlaterDatabaseRepository<T>
{
    public Task<BlaterResult<T>> FindOne(string id);
    public Task<BlaterResult<T>> FindOne(Expression<Func<T, bool>> predicate);
    public Task<BlaterResult<IReadOnlyList<T>>> FindMany(Expression<Func<T, bool>> predicate);

    public Task<BlaterResult> Upsert(T entity);

    public Task<BlaterResult?> DeleteOne(string id);
    public Task<BlaterResult<int>> DeleteMany(Expression<Func<T, bool>> predicate);

    public Task<BlaterResult<int>> Count();
    public Task<BlaterResult<int>> Count(Expression<Func<T, bool>> predicate);

    public Task<BlaterResult<PaginationResponse<T>>> GetPage(PaginationRequest<T> request);
}