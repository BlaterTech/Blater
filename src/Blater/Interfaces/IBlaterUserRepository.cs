using Blater.Models.User;

namespace Blater.Interfaces;

public interface IBlaterUserRepository<TUser> where TUser : BaseBlaterUser
{
    Task<TUser?> GetUserInfo(string email);
    Task<TUser?> GetUserInfo(TUser user);
    
    Task<TUser?> CreateUserAsync(TUser user, string password);
    
    Task<TUser?> UpdateUserAsync(TUser user);
    
    Task<bool> DeleteUserAsyncById(BlaterId id);
    Task<bool> DeleteUserAsync(TUser user);
}