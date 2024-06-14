using Blater.Models.User;
using Blater.Query.Models;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionStore
{
    Task<BlaterResult<BlaterPermission<string>>> Create(BlaterPermission<string> permission);
    
    Task<BlaterResult<BlaterPermission<string>>> Update(BlaterPermission<string> permission);
    
    Task<BlaterResult<bool>> Delete(BlaterPermission<string> permission);
    Task<BlaterResult<bool>> Delete(BlaterId id);
    Task<BlaterResult<bool>> Delete(BlaterQuery query);
    Task<BlaterResult<IReadOnlyList<BlaterPermission<string>>>> GetAll();
    Task<BlaterResult<BlaterPermission<string>>> GetById(BlaterId id);
    Task<BlaterResult<BlaterPermission<string>>> GetPermission(string permissionName);
}