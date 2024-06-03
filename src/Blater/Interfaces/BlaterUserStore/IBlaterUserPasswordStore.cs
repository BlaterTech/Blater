using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserPasswordStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task SetPasswordHashAsync(TUser user, string? passwordHash, CancellationToken cancellationToken);
    
    Task<BlaterResult<string?>> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken);
    
    Task<BlaterResult<bool>> HasPasswordAsync(TUser user, CancellationToken cancellationToken); 
}