using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserLockoutStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task<BlaterResult<DateTimeOffset?>> GetLockoutEndDateAsync(TUser user, CancellationToken cancellationToken);
    
    Task SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken);
    
    Task<BlaterResult<int>> IncrementAccessFailedCountAsync(TUser user, CancellationToken cancellationToken);
    
    Task ResetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken);
    
    Task<BlaterResult<int>> GetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken);
    
    Task<BlaterResult<bool>> GetLockoutEnabledAsync(TUser user, CancellationToken cancellationToken);
    
    Task SetLockoutEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken);
}