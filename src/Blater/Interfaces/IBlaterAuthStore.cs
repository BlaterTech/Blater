using Blater.Resullts;

namespace Blater.Interfaces;


/// <summary>
/// This is the same as the IBlaterDatabaseRepository but returns a BlaterResult instead
/// </summary>
public interface IBlaterAuthStore
{
    /// <summary>
    /// </summary>
    /// <param name="userId">The id of the user</param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<BlaterUserInternal>> GetUserAsyncById(string userId);

    /// <summary>
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<BlaterUserInternal>> GetUserAsyncByLogin(string loginProvider, string loginKey);

    /// <summary>
    ///     Authenticate a user with email and password
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <param name="password"></param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<BlaterUserInternal>> GetUserAsync(string loginProvider, string loginKey, string password);
    
    Task<BlaterResult<bool>> CreateUserAsync(BlaterUserInternal user, string password);

    Task<BlaterResult<bool>> UpdateUserAsync(BlaterUserInternal user);

    Task<BlaterResult<bool>> DeleteUserAsyncById(string userId);
    Task<BlaterResult<bool>> DeleteUserAsync(BlaterUserInternal user);
}