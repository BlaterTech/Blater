using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserStore<TUser> : IDisposable where TUser : class
{
    Task<BlaterResult<BlaterId?>> GetUserIdAsync(TUser user);
    
    Task<BlaterResult<string?>> GetUserNameAsync(TUser user);

    Task SetUserNameAsync(TUser user, string? userName);
    
    Task<BlaterResult<bool>> CreateAsync(TUser user);
    
    Task<BlaterResult<bool>> UpdateAsync(TUser user);
    
    Task<BlaterResult<bool>> DeleteAsync(TUser user);
    Task<BlaterResult<bool>> DeleteAsync(string userId);
    
    Task<BlaterResult<TUser?>> FindByIdAsync(string userId);
    
    Task<BlaterResult<TUser?>> FindByNameAsync(string userName);
}