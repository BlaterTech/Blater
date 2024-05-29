using Blater.Query.Models;
using Blater.Resullts;

namespace Blater.Interfaces;

public interface IBlaterDatabaseStore
{
    public Task<BlaterResult<string>> FindOne(string id);
    public Task<BlaterResult<string>> FindOne(BlaterQuery query);

    public Task<BlaterResult<IEnumerable<string>>> FindMany(string partition, BlaterQuery query);

    public Task<BlaterResult<bool>> Upsert(string id, string json);

    public Task<BlaterResult?> DeleteOne(string id);

    public Task<BlaterResult<int>> Count(string partition);
    public Task<BlaterResult<int>> Count(string partition, BlaterQuery query);
}