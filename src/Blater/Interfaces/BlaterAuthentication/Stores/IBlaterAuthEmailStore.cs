using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

public interface IBlaterAuthEmailStore
{
    Task<BlaterResult<BlaterUser>> SetEmail(BlaterUser user, string? email);
    
    Task<BlaterResult<BlaterUser>> SetEmailConfirmed(BlaterUser user, bool confirmed);
    
    Task<BlaterResult<BlaterUser?>> FindByEmail(string email);
}