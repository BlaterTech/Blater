using Blater.Models.User;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthUserRoleStore<TUser> where TUser : BaseBlaterUser
{
    Task<BlaterResult<bool>> AddToRole(TUser user, string roleName);
    
    Task<BlaterResult<bool>> RemoveFromRole(TUser user, string roleName);
    
    Task<BlaterResult<bool>> IsInRole(TUser user, string roleName);
    
    Task<BlaterResult<IEnumerable<string>>> GetRoles(TUser user);
    
    Task<BlaterResult<IEnumerable<TUser>>> GetUsersInRole(string roleName);
}