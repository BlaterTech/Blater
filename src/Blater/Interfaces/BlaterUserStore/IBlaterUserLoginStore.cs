using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserLoginStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task AddLoginAsync(TUser user, BlaterLoginInfo login, CancellationToken cancellationToken);
    
    Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey, CancellationToken cancellationToken);
    
    Task<BlaterResult<IEnumerable<BlaterLoginInfo>>> GetLoginsAsync(TUser user, CancellationToken cancellationToken);
    
    Task<BlaterResult<TUser>?> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken);
}