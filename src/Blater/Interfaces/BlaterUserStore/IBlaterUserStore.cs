using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserStore<TUser> : IDisposable where TUser : class
{
    Task<BlaterResult<BlaterId?>> GetUserIdAsync(TUser user, CancellationToken cancellationToken);
    
    Task<BlaterResult<string?>> GetUserNameAsync(TUser user, CancellationToken cancellationToken);

    Task SetUserNameAsync(TUser user, string? userName, CancellationToken cancellationToken);
    
    Task<BlaterResult<string?>> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken);

    Task SetNormalizedUserNameAsync(TUser user, string? normalizedName, CancellationToken cancellationToken);
    
    Task<BlaterResult<bool>> CreateAsync(TUser user, CancellationToken cancellationToken);
    
    Task<BlaterResult<bool>> UpdateAsync(TUser user, CancellationToken cancellationToken);
    
    Task<BlaterResult<bool>> DeleteAsync(TUser user, CancellationToken cancellationToken);
    
    Task<BlaterResult<TUser?>> FindByIdAsync(string userId, CancellationToken cancellationToken);
    
    Task<BlaterResult<TUser?>> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);
}