using Blater.BlaterResults;

namespace Blater.Interfaces;

public interface IBlaterDatabaseStore
{
    public Task<BlaterResult<string>> FindOne(string table, Guid id);
    public Task<BlaterResult<string>> FindOne(string table, string query);

    public Task<BlaterResult<IEnumerable<string>>> FindMany(string table, string query);

    public Task<BlaterResult> Upsert(string table, string json);

    public Task<BlaterResult> DeleteOne(Guid id);

    public Task<BlaterResult<int>> Count(string table);
    public Task<BlaterResult<int>> Count(string table, string query);
}