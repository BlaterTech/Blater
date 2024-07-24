using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

public interface IBlaterAuthEmailStore
{
    Task<BlaterResult<BlaterUser?>> FindByEmail(string email);

    Task<BlaterResult<bool>> ResetEmail(string oldEmail, string newEmail, string password);
}