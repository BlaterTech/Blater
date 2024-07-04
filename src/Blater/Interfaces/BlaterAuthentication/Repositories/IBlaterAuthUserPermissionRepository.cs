using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthUserPermissionRepository
{
    Task<bool> IsInPermission(string userId, string permissionName);
    Task<bool> IsInPermission(BlaterUser user, BlaterPermission permission);

    Task<IReadOnlyList<BlaterUser>> GetUsersInPermission(string permissionName);
    Task<IReadOnlyList<BlaterUser>> GetUsersInPermission(BlaterPermission permission);
}