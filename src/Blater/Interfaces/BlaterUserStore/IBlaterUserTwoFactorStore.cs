using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserTwoFactorStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task SetTwoFactorEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken);
    
    Task<BlaterResult<bool>> GetTwoFactorEnabledAsync(TUser user, CancellationToken cancellationToken);
}