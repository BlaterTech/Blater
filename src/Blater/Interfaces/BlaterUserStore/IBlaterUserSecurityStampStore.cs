using Blater.Resullts;

namespace Blater.Interfaces.BlaterUserStore;

public interface IBlaterUserSecurityStampStore<TUser> : IBlaterUserStore<TUser> where TUser : class
{
    Task SetSecurityStampAsync(TUser user, string stamp);

    Task<BlaterResult<string?>> GetSecurityStampAsync(TUser user);
}