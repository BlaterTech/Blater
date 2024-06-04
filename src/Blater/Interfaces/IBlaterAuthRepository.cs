namespace Blater.Interfaces;

public interface IBlaterAuthRepository
{
    Task<BlaterUser> GetUserAsyncById(string userId);
    
    /// <summary>
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterUser> GetUserAsyncByLogin(string loginProvider, string loginKey);
    
    /// <summary>
    ///     Authenticate a user with email and password
    /// </summary>
    /// <param name="login">Can be either login or email</param>
    /// <param name="password"></param>
    /// <returns>Returns null if not found</returns>
    Task<BlaterUser> GetUserAsync(string login, string password);
    
    Task<bool> CreateUserAsync(BlaterUser user, string password);
    
    Task<bool> UpdateUserAsync(BlaterUser user);
    
    Task<bool> DeleteUserAsyncById(string userId);
    Task<bool> DeleteUserAsync(BlaterUser user);
}