using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

//TODO ban* user

public interface IBlaterAuthLockoutStore
{
    Task SetLockoutEndDate(BlaterUser user, DateTimeOffset? lockoutEnd);
    
    Task<BlaterResult<int>> IncrementAccessFailedCount(BlaterUser user);
    
    Task ResetAccessFailedCount(BlaterUser user);
    
    Task SetLockoutEnabled(BlaterUser user, bool enabled);
}