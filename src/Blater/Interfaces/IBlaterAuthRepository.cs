namespace Blater.Interfaces;

public interface IBlaterAuthRepository
{
    Task<BlaterUserInternal> GetUserAsyncById(string userId);
    
    /// <summary>
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterUserInternal> GetUserAsyncByLogin(string loginProvider, string loginKey);
    
    /// <summary>
    ///     Authenticate a user with email and password
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <param name="password"></param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterUserInternal> GetUserAsync(string loginProvider, string loginKey, string password);
    
    Task<bool> CreateUserAsync(BlaterUserInternal user, string password);
    
    Task<bool> UpdateUserAsync(BlaterUserInternal user);
    
    Task<bool> DeleteUserAsyncById(string userId);
    Task<bool> DeleteUserAsync(BlaterUserInternal user);
}