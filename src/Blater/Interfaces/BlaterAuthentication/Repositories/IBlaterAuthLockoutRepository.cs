using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

//TODO ban* user

public interface IBlaterAuthLockoutRepository
{
    Task<BlaterUser> SetLockoutEndDate(BlaterUser user, DateTimeOffset? lockoutEnd);
    
    Task<int> IncrementAccessFailedCount(BlaterUser user);
    
    Task<BlaterUser> ResetAccessFailedCount(BlaterUser user);
    
    Task<BlaterUser> SetLockoutEnabled(BlaterUser user, bool enabled);
}