using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

// Login History
// Device login
// Provider login

public interface IBlaterAuthLoginStore<TUser> where TUser : BaseBlaterUser
{
    Task AddLogin(TUser user, BlaterLoginInfo login);
    
    Task RemoveLogin(TUser user, string loginProvider, string providerKey);
    
    Task<BlaterResult<IEnumerable<BlaterLoginInfo>>> GetLogins(TUser user);
    
    Task<BlaterResult<TUser>> FindByLogin(string loginProvider, string providerKey);
}