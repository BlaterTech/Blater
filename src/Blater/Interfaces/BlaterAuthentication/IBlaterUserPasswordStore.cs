using Blater.Models.User;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterUserPasswordStore<TUser> : IBlaterUserStore<TUser> where TUser : BaseBlaterUser
{
    Task SetPasswordHashAsync(TUser user, string? passwordHash);
    
    Task<BlaterResult<string>> GetPasswordHashAsync(TUser user);
    
    Task<BlaterResult<bool>> HasPasswordAsync(TUser user); 
}