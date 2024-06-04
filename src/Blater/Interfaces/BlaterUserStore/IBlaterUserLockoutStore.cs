using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserLockoutStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task<BlaterResult<DateTimeOffset?>> GetLockoutEndDateAsync(TUser user);
    
    Task SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd);
    
    Task<BlaterResult<int>> IncrementAccessFailedCountAsync(TUser user);
    
    Task ResetAccessFailedCountAsync(TUser user);
    
    Task<BlaterResult<int>> GetAccessFailedCountAsync(TUser user);
    
    Task<BlaterResult<bool>> GetLockoutEnabledAsync(TUser user);
    
    Task SetLockoutEnabledAsync(TUser user, bool enabled);
}