using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPermissionRoleStore
{
    Task<BlaterResult<BlaterRole>> AddToRole(BlaterRole role, BlaterPermission permission);
    Task<BlaterResult<BlaterRole>> AddToRole(string roleName, BlaterPermission permission);

    Task<BlaterResult<BlaterRole>> RemoveFromRole(BlaterRole role, BlaterPermission permission);
    Task<BlaterResult<BlaterRole>> RemoveFromRole(string roleName, BlaterPermission permission);

    Task<BlaterResult<IReadOnlyList<BlaterRole>>> GetRoles(BlaterPermission permission);
}