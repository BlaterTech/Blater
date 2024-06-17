using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthUserRoleStore
{
    Task<BlaterResult<BlaterUser>> AddToRole(BlaterUser user, string roleName);
    Task<BlaterResult<BlaterUser>> AddToRole(BlaterUser user, BlaterRole role);

    Task<BlaterResult<BlaterUser>> RemoveFromRole(BlaterUser user, string roleName);
    Task<BlaterResult<BlaterUser>> RemoveFromRole(BlaterUser user, BlaterRole role);

    Task<BlaterResult<bool>> IsInRole(BlaterUser user, string roleName);
    Task<BlaterResult<bool>> IsInRole(BlaterUser user, BlaterRole role);

    Task<BlaterResult<IReadOnlyList<BlaterRole>>> GetRoles(BlaterUser user);
    Task<BlaterResult<IReadOnlyList<string>>> GetRoleNames(BlaterUser user);
    
    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInRole(string roleName);
    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInRole(BlaterRole role);
    
    Task<BlaterResult<bool>> IsInPermission(BlaterUser user, string permissionName);
    Task<BlaterResult<bool>> IsInPermission(BlaterUser user, BlaterPermission permission);
    
    Task<BlaterResult<IReadOnlyList<string>>> GetPermissions(BlaterUser user);
    
    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInPermission(string permissionName);
    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInPermission(BlaterPermission permission);
}