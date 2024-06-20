using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

public interface IBlaterAuthPasswordStore
{
    Task<BlaterResult<BlaterUser>> SetPasswordHash(BlaterUser user, string? passwordHash);
}