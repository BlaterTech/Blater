using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserStore<TUser> : IDisposable where TUser : class
{
    Task<BlaterResult<BlaterId>> GetUserIdAsync(TUser user);
    
    Task<BlaterResult<TUser>> FindByIdAsync(string userId);
    
    Task<BlaterResult<TUser>> FindByNameAsync(string userName);
}