using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthUserPermissionStore
{
    Task<BlaterResult<bool>> IsInPermission(string userId, string permissionName);
    Task<BlaterResult<bool>> IsInPermission(BlaterUser user, BlaterPermission permission);
    
    Task<BlaterResult<IReadOnlyList<string>>> GetPermissions(BlaterUser user);
    
    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInPermission(string permissionName);
    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInPermission(BlaterPermission permission);
}