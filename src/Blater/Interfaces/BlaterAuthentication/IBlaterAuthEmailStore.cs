using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthEmailStore<TUser> where TUser : BaseBlaterUser
{
    Task SetEmail(TUser user, string? email);
    
    Task<BlaterResult<string>> GetEmail(TUser user);
    
    Task<BlaterResult<bool>> GetEmailConfirmed(TUser user);
    
    Task SetEmailConfirmed(TUser user, bool confirmed);
    
    Task<BlaterResult<TUser>> FindByEmail(string email);
}