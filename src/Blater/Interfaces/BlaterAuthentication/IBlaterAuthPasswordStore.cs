using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPasswordStore<in TUser> where TUser : BaseBlaterUser
{
    Task SetPasswordHash(TUser user, string? passwordHash);
    
    Task<BlaterResult<bool>> HasPassword(TUser user); 
}