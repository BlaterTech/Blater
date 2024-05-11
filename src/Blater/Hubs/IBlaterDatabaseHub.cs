using Blater.Models.Pagination;

namespace Blater.Hubs;

public interface IBlaterDatabaseHub
{
    Task<BlaterResult> Upsert(string table, Guid id, string fullTypeName, string json);
    Task<BlaterResult<string>> Get(string table, Guid id);
    Task<BlaterResult<string>> QueryOne(string table, string conditionText);
    Task<BlaterResult<IReadOnlyList<string>>> QueryMany(string table, string conditionText);
    IAsyncEnumerable<string> QueryManyAsync(string table, string conditionText);
    Task<BlaterResult> Delete(string table, Guid id);
    Task<BlaterResult<int>> DeleteMany(string table, string conditionText);
    Task<BlaterResult<int>> Count(string table);
    Task<BlaterResult<int>> CountWithCondition(string table, string conditionText);
    Task<BlaterResult<PaginationResponse>> Pagination(PaginationRequest request);
}