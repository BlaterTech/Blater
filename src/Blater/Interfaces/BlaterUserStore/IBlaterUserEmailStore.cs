using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserEmailStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task SetEmailAsync(TUser user, string? email);
    
    Task<BlaterResult<string?>> GetEmailAsync(TUser user);
    
    Task<BlaterResult<bool>> GetEmailConfirmedAsync(TUser user);
    
    Task SetEmailConfirmedAsync(TUser user, bool confirmed);
    
    Task<BlaterResult<TUser?>> FindByEmailAsync(string normalizedEmail);
}