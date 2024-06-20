using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthEmailStore
{
    Task<BlaterUser> SetEmail(BlaterUser user, string? email);
    
    Task<BlaterUser> SetEmailConfirmed(BlaterUser user, bool confirmed);
    
    Task<BlaterUser> FindByEmail(string email);
}