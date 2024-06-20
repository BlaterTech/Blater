using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthEmailRepository
{
    Task<BlaterUser> SetEmailConfirmed(BlaterUser user, bool confirmed);
    
    Task<BlaterUser> FindByEmail(string email);
}