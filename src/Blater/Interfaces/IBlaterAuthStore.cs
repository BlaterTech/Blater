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
    Task<BlaterResult<BlaterUser>> GetUserAsyncById(string userId);

    /// <summary>
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<BlaterUser>> GetUserAsyncByLogin(string loginProvider, string loginKey);
    
    /// <summary>
    ///     Authenticate a user with email and password
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <param name="password"></param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterResult<BlaterUser>> GetUserAsync(string login, string password);
    
    Task<BlaterResult<bool>> CreateUserAsync(BlaterUser user, string password);

    Task<BlaterResult<bool>> UpdateUserAsync(BlaterUser user);

    Task<BlaterResult<bool>> DeleteUserAsyncById(string userId);
    Task<BlaterResult<bool>> DeleteUserAsync(BlaterUser user);
}