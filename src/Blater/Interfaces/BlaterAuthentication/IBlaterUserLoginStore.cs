using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

// Login History
// Device login
// Provider login

public interface IBlaterUserLoginStore<TUser> where TUser : class
{
    Task AddLoginAsync(TUser user, BlaterLoginInfo login);
    
    Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey);
    
    Task<BlaterResult<IEnumerable<BlaterLoginInfo>>> GetLoginsAsync(TUser user);
    
    Task<BlaterResult<TUser>> FindByLoginAsync(string loginProvider, string providerKey);
}