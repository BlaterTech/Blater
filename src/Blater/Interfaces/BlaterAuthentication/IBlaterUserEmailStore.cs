using Blater.Models.User;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterUserEmailStore<TUser> where TUser : BaseBlaterUser
{
    Task SetEmailAsync(TUser user, string? email);
    
    Task<BlaterResult<string>> GetEmailAsync(TUser user);
    
    Task<BlaterResult<bool>> GetEmailConfirmedAsync(TUser user);
    
    Task SetEmailConfirmedAsync(TUser user, bool confirmed);
    
    Task<BlaterResult<TUser>> FindByEmailAsync(string normalizedEmail);
}