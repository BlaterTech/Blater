using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionRoleStore
{
    Task<BlaterResult<BlaterRole>> AddToRole(BlaterRole role, BlaterPermission<string> permission);
    Task<BlaterResult<BlaterRole>> AddToRole(string roleName, BlaterPermission<string> permission);

    Task<BlaterResult> RemoveFromRole(BlaterRole role, BlaterPermission<string> permission);
    Task<BlaterResult> RemoveFromRole(string roleName, BlaterPermission<string> permission);

    Task<BlaterResult<IReadOnlyList<BlaterRole>>> GetRoles(BlaterPermission<string> permission);
}