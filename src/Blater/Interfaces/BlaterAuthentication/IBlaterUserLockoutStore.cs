using Blater.Models.User;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

//TODO ban* user

public interface IBlaterUserLockoutStore<in TUser> where TUser : BaseBlaterUser
{
    Task<BlaterResult<DateTimeOffset>> GetLockoutEndDateAsync(TUser user);
    
    Task SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd);
    
    Task<BlaterResult<int>> IncrementAccessFailedCountAsync(TUser user);
    
    Task ResetAccessFailedCountAsync(TUser user);
    
    Task<BlaterResult<int>> GetAccessFailedCountAsync(TUser user);
    
    Task<BlaterResult<bool>> GetLockoutEnabledAsync(TUser user);
    
    Task SetLockoutEnabledAsync(TUser user, bool enabled);
}