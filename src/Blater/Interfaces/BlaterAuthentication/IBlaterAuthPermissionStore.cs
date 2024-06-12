using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionStore
{
    Task<BlaterResult> Create(string permission);
    
    Task<BlaterResult> Update(string permissionOld, string permissionNew);
    
    Task<BlaterResult> Delete(string permission);
}