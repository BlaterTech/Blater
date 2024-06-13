using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthUserRoleStore<TRole>
    where TRole : BaseBlaterRole
{
    Task<BlaterResult<BlaterUser>> AddToRole(BlaterUser user, string roleName);
    Task<BlaterResult<BlaterUser>> AddToRole(BlaterUser user, TRole role);

    Task<BlaterResult> RemoveFromRole(BlaterUser user, string roleName);
    Task<BlaterResult> RemoveFromRole(BlaterUser user, TRole role);

    Task<BlaterResult<bool>> IsInRole(BlaterUser user, string roleName);
    Task<BlaterResult<bool>> IsInRole(BlaterUser user, TRole role);

    Task<BlaterResult<IReadOnlyList<TRole>>> GetRoles(BlaterUser user);
    Task<BlaterResult<IReadOnlyList<string>>> GetRoleNames(BlaterUser user);

    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInRole(string roleName);
    Task<BlaterResult<IReadOnlyList<BlaterUser>>> GetUsersInRole(TRole role);
}