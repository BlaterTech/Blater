using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthEmailRepository
{
    Task<BlaterUser> FindByEmail(string email);
    
    Task<bool> ResetEmail(string oldEmail, string newEmail, string password);
}