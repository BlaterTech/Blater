using System.Collections.Generic;
using System.Threading.Tasks;
using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthUserRoleRepository
{
    Task<BlaterUser> AddToRole(string userId, string roleName);
    Task<BlaterUser> AddToRole(BlaterUser user, BlaterRole role);

    Task<BlaterUser> RemoveFromRole(string userId, string roleName);
    Task<BlaterUser> RemoveFromRole(BlaterUser user, BlaterRole role);

    Task<bool> IsInRole(string userId, string roleName);
    Task<bool> IsInRole(BlaterUser user, BlaterRole role);

    Task<IReadOnlyList<BlaterRole>> GetRoles(BlaterUser user);

    Task<IReadOnlyList<BlaterUser>> GetUsersInRole(string roleName);
    Task<IReadOnlyList<BlaterUser>> GetUsersInRole(BlaterRole role);
}