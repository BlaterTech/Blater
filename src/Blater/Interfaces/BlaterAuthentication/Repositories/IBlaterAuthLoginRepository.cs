using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

// Login History
// Device login
// Provider login

public interface IBlaterAuthLoginStore
{
    Task<BlaterUser> AddLogin(BlaterUser user, BlaterLoginInfo login);
    
    Task<BlaterUser> RemoveLogin(BlaterUser user, string loginProvider, string providerKey);
    
    Task<IEnumerable<BlaterLoginInfo>> GetLogins(BlaterUser user);
    
    Task<BlaterUser> FindByLogin(string loginProvider, string providerKey);
}