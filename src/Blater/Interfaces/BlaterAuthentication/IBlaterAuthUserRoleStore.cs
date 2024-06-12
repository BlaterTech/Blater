using Blater.Models.User;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthUserRoleStore<TUser, TRole> where TUser : BaseBlaterUser
{
    Task<BlaterResult<TUser>> AddToRole(TUser user, string roleName);
    Task<BlaterResult<TUser>> AddToRole(TUser user, TRole role);
    
    Task<BlaterResult> RemoveFromRole(TUser user, string roleName);
    Task<BlaterResult> RemoveFromRole(TUser user, TRole role);
    
    Task<BlaterResult<bool>> IsInRole(TUser user, string roleName);
    Task<BlaterResult<bool>> IsInRole(TUser user, TRole role);
    
    Task<BlaterResult<IReadOnlyList<TRole>>> GetRoles(TUser user);
    Task<BlaterResult<IReadOnlyList<string>>> GetRoleNames(TUser user);
    
    Task<BlaterResult<IReadOnlyList<TUser>>> GetUsersInRole(string roleName);
    Task<BlaterResult<IReadOnlyList<TUser>>> GetUsersInRole(TRole role);
}