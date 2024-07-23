using System.Collections.Generic;
using System.Threading.Tasks;
using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthPermissionRoleRepository
{
    Task<BlaterRole> AddToRole(BlaterRole role, BlaterPermission permission);
    Task<BlaterRole> AddToRole(string roleName, string permissionName);

    Task<BlaterRole> RemoveFromRole(BlaterRole role, BlaterPermission permission);
    Task<BlaterRole> RemoveFromRole(string roleName, string permissionName);

    Task<IReadOnlyList<BlaterRole>> GetRoles(string permissionName);
}