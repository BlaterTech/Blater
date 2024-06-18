using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionRoleStore
{
    Task<BlaterResult<BlaterRole>> AddToRole(BlaterRole role, BlaterPermission permission);
    Task<BlaterResult<BlaterRole>> AddToRole(string roleName, string permissionName);

    Task<BlaterResult<BlaterRole>> RemoveFromRole(BlaterRole role, BlaterPermission permission);
    Task<BlaterResult<BlaterRole>> RemoveFromRole(string roleName, string permissionName);

    Task<BlaterResult<IReadOnlyList<BlaterRole>>> GetRoles(string permissionName);
}