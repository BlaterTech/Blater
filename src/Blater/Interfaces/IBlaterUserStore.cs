using Blater.Models.User;
using Blater.Resullts;

namespace Blater.Interfaces;

/// <summary>
/// This is the same as the IBlaterDatabaseRepository but returns a BlaterResult instead
/// </summary>
public interface IBlaterUserStore<TUser> where TUser : BaseBlaterUser
{
    Task<BlaterResult<TUser>> GetUserInfo(string email);
    Task<BlaterResult<TUser>> GetUserInfo(TUser user);
    
    Task<BlaterResult<TUser>> CreateUserAsync(TUser user, string password);

    Task<BlaterResult<TUser>> UpdateUserAsync(TUser user);

    Task<BlaterResult<bool>> DeleteUserAsyncById(BlaterId id);
    Task<BlaterResult<bool>> DeleteUserAsync(TUser user);
}