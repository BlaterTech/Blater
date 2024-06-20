using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

// Login History
// Device login
// Provider login

public interface IBlaterAuthLoginStore
{
    Task AddLogin(BlaterUser user, BlaterLoginInfo login);
    
    Task RemoveLogin(BlaterUser user, string loginProvider, string providerKey);
    
    Task<BlaterResult<IEnumerable<BlaterLoginInfo>>> GetLogins(BlaterUser user);
    
    Task<BlaterResult<BlaterUser>> FindByLogin(string loginProvider, string providerKey);
}