using Blater.Models.User;
using Blater.Resullts;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterUserSecurityStampStore<in TUser> where TUser : BaseBlaterUser
{
    Task SetSecurityStampAsync(TUser user, string stamp);

    Task<BlaterResult<string>> GetSecurityStampAsync(TUser user);
}