using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthUserRoleStore
{
    Task<BlaterResult<BlaterUser>> AddToRole(string userId, string roleName);
    Task<BlaterResult<BlaterUser>> AddToRole(BlaterUser user, BlaterRole role);

    Task<BlaterResult<BlaterUser>> RemoveFromRole(string userId, string roleName);
    Task<BlaterResult<BlaterUser>> RemoveFromRole(BlaterUser user, BlaterRole role);

    Task<BlaterResult<bool>> IsInRole(string userId, string roleName);
    Task<BlaterResult<bool>> IsInRole(BlaterUser user, BlaterRole role);

    Task<BlaterResult<IReadOnlyList<BlaterRole>>> GetRoles(BlaterUser user);
    Task<BlaterResult<IReadOnlyList<string>>> GetRoleNames(BlaterUser user);
    
    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInRole(string roleName);
    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInRole(BlaterRole role);
}