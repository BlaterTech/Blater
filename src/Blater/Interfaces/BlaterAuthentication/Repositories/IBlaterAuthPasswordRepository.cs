namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthPasswordRepository
{
    Task<bool> ResetPassword(string email, string oldPassword, string newPassword);
}