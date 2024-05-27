using Blater.BlaterResults;

namespace Blater.Interfaces;

public interface IBlaterAuth
{
    /// <summary>
    /// </summary>
    /// <param name="userId">The id of the user</param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<BlaterUser>> GetUserAsyncById(Guid userId);

    /// <summary>
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<BlaterUser>> GetUserAsyncByLogin(string login);

    /// <summary>
    ///     Authenticate a user with email and password
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <param name="password"></param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<BlaterUser>?> GetUserAsync(string login, string password);

    Task<BlaterResult?> CreateUserAsync(BlaterUser user, string password);

    Task<BlaterResult?> UpdateUserAsync(BlaterUser user);

    Task<BlaterResult?> DeleteUserAsyncById(Guid userId);
    Task<BlaterResult?> DeleteUserAsync(BlaterUser user);
}