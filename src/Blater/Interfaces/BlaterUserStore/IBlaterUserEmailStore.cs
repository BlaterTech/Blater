using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserEmailStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task SetEmailAsync(TUser user, string? email, CancellationToken cancellationToken);
    
    Task<BlaterResult<string?>> GetEmailAsync(TUser user, CancellationToken cancellationToken);
    
    Task<BlaterResult<bool>> GetEmailConfirmedAsync(TUser user, CancellationToken cancellationToken);
    
    Task SetEmailConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken);
    
    Task<BlaterResult<TUser?>> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken);
    
    Task<BlaterResult<string?>> GetNormalizedEmailAsync(TUser user, CancellationToken cancellationToken);
    
    Task SetNormalizedEmailAsync(TUser user, string? normalizedEmail, CancellationToken cancellationToken);
}