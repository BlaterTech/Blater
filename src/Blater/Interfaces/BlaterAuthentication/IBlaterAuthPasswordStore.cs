using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthPasswordStore
{
    Task SetPasswordHash(BlaterUser user, string? passwordHash);
    
    Task<BlaterResult<bool>> HasPassword(BlaterUser user); 
}