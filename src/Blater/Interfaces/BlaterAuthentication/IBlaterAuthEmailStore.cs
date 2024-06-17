using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthEmailStore
{
    Task SetEmail(BlaterUser user, string? email);
    
    Task<BlaterResult<string>> GetEmail(BlaterUser user);
    
    Task<BlaterResult<bool>> GetEmailConfirmed(BlaterUser user);
    
    Task SetEmailConfirmed(BlaterUser user, bool confirmed);
    
    Task<BlaterResult<BlaterUser?>> FindByEmail(string email);
}