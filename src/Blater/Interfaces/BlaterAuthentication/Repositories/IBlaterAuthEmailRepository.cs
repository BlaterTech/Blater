using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthEmailStore
{
    Task<bool> SetEmail(BlaterUser user, string? email);
    
    Task<bool> SetEmailConfirmed(BlaterUser user, bool confirmed);
    
    Task<BlaterUser> FindByEmail(string email);
}