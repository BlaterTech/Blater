using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserSecurityStampStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task SetSecurityStampAsync(TUser user, string stamp, CancellationToken cancellationToken);

    Task<BlaterResult<string?>> GetSecurityStampAsync(TUser user, CancellationToken cancellationToken);
}