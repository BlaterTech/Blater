using Blater.Resullts;

namespace Blater.Interfaces;

public interface IBlaterAuthRepository
{
    /// <summary>
    /// </summary>
    /// <param name="userId">The id of the user</param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterUser?> GetUserAsyncById(Guid userId);

    /// <summary>
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterUser?> GetUserAsyncByLogin(string login);

    /// <summary>
    ///     Authenticate a user with email and password
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <param name="password"></param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterUser?> GetUserAsync(string login, string password);

    Task<BlaterUser?> CreateUserAsync(BlaterUser user, string password);

    Task<BlaterUser> UpdateUserAsync(BlaterUser user);

    Task<BlaterUser?> DeleteUserAsyncById(Guid userId);
    Task<BlaterUser?> DeleteUserAsync(BlaterUser user);
}