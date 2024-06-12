using Blater.Query.Models;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionStore
{
    Task<BlaterResult> Create(string permission);
    
    Task<BlaterResult> Update(string permission);
    
    Task<BlaterResult> Delete(string permission);
    Task<BlaterResult> Delete(BlaterId id);
    Task<BlaterResult> Delete(BlaterQuery query);
}