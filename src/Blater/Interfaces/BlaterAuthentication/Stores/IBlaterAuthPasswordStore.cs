using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

public interface IBlaterAuthPasswordStore
{
    Task<BlaterResult<bool>> ResetPassword(string email, string oldPassword, string newPassword);
}