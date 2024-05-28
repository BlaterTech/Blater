using Blater.Query.Models;
using Blater.Resullts;

namespace Blater.Interfaces;

public interface IBlaterDatabaseStore
{
    public Task<BlaterResult<string>> FindOne(Guid id);
    public Task<BlaterResult<string>> FindOne(string typeName, BlaterQuery query);

    public Task<BlaterResult<IEnumerable<string>>> FindMany(string typeName, BlaterQuery query);

    public Task<BlaterResult> Upsert(string typeName, string json);

    public Task<BlaterResult?> DeleteOne(Guid id);

    public Task<BlaterResult<int>> Count(string typeName);
    public Task<BlaterResult<int>> Count(string typeName, BlaterQuery query);
}