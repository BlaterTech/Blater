using Blater.Resullts;

namespace Blater.Interfaces;


/// <summary>
/// This is the same as the IBlaterDatabaseRepository but returns a BlaterResult instead
/// </summary>
public interface IBlaterAuthStore<in TUser> where TUser : BlaterUser
{
    Task<BlaterResult<bool>> CreateUserAsync(TUser user, string password);
    Task<BlaterResult<bool>> UpsertUserAsync(TUser user, string password);

    Task<BlaterResult<bool>> UpdateUserAsync(TUser user);

    Task<BlaterResult<bool>> DeleteUserAsyncById(string userId);
    Task<BlaterResult<bool>> DeleteUserAsync(TUser user);
}