using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthPasswordStore
{
    Task<BlaterUser> SetPasswordHash(BlaterUser user, string? passwordHash);
}