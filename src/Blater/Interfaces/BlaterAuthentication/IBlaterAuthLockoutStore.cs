using Blater.Models.User;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

//TODO ban* user

public interface IBlaterAuthLockoutStore<in TUser> where TUser : BaseBlaterUser
{
    Task<BlaterResult<DateTimeOffset>> GetLockoutEndDate(TUser user);
    
    Task SetLockoutEndDate(TUser user, DateTimeOffset? lockoutEnd);
    
    Task<BlaterResult<int>> IncrementAccessFailedCount(TUser user);
    
    Task ResetAccessFailedCount(TUser user);
    
    Task<BlaterResult<int>> GetAccessFailedCount(TUser user);
    
    Task<BlaterResult<bool>> GetLockoutEnabled(TUser user);
    
    Task SetLockoutEnabled(TUser user, bool enabled);
}