using Blater.BlaterResults;

namespace Blater.Interfaces;

public interface IBlaterDatabaseStore
{
    public Task<BlaterResult<string>> FindOne(string typeName, Guid id);
    public Task<BlaterResult<string>> FindOne(string typeName, string query);

    public Task<BlaterResult<IEnumerable<string>>> FindMany(string typeName, string query);

    public Task<BlaterResult> Upsert(string typeName, string json);

    public Task<BlaterResult> DeleteOne(Guid id);

    public Task<BlaterResult<int>> Count(string typeName);
    public Task<BlaterResult<int>> Count(string typeName, string query);
}