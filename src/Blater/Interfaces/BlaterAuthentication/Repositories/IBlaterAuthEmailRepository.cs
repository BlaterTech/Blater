using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthEmailRepository
{
    Task<BlaterUser> FindByEmail(string email);
    
    Task<BlaterUser> SetConfirmEmail(string email);
}