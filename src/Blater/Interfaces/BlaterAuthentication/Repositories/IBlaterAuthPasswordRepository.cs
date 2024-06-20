using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthPasswordRepository
{
    Task<BlaterUser> SetPasswordHash(BlaterUser user, string? passwordHash);
}