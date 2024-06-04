using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserPasswordStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task SetPasswordHashAsync(TUser user, string? passwordHash);
    
    Task<BlaterResult<string?>> GetPasswordHashAsync(TUser user);
    
    Task<BlaterResult<bool>> HasPasswordAsync(TUser user); 
}