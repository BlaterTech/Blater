using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserLoginStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task AddLoginAsync(TUser user, BlaterLoginInfo login);
    
    Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey);
    
    Task<BlaterResult<IEnumerable<BlaterLoginInfo>>> GetLoginsAsync(TUser user);
    
    Task<BlaterResult<TUser?>> FindByLoginAsync(string loginProvider, string providerKey);
}