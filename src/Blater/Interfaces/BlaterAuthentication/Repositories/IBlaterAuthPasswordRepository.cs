using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthPasswordStore
{
    Task SetPasswordHash(BlaterUser user, string? passwordHash);
}