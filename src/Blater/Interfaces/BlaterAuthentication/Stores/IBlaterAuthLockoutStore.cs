using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

//TODO ban* user

public interface IBlaterAuthLockoutStore
{
    Task<BlaterResult<DateTimeOffset>> GetLockoutEndDate(BlaterUser user);
    
    Task SetLockoutEndDate(BlaterUser user, DateTimeOffset? lockoutEnd);
    
    Task<BlaterResult<int>> IncrementAccessFailedCount(BlaterUser user);
    
    Task ResetAccessFailedCount(BlaterUser user);
    
    Task<BlaterResult<int>> GetAccessFailedCount(BlaterUser user);
    
    Task<BlaterResult<bool>> GetLockoutEnabled(BlaterUser user);
    
    Task SetLockoutEnabled(BlaterUser user, bool enabled);
}