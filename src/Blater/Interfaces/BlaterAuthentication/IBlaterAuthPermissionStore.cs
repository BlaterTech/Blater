using Blater.Models.User;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionStore
{
    Task<BlaterResult<BlaterPermission<string>>> Create(BlaterPermission<string> permission);
    
    Task<BlaterResult<BlaterPermission<string>>> Update(BlaterPermission<string> permission);
    
    Task<BlaterResult<bool>> Delete(BlaterPermission<string> permission);
    Task<BlaterResult<bool>> Delete(string permissionName);
    Task<BlaterResult<bool>> Delete(BlaterQuery query);
    
    Task<BlaterResult<IReadOnlyList<BlaterRole>>> Get();
    Task<BlaterResult<BlaterPermission<string>>> Get(BlaterId id);
}