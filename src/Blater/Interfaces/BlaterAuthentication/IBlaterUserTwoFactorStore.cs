using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterUserTwoFactorStore<TUser>  where TUser : BaseBlaterUser
{
    Task EnableTwoFactorAsync(TUser user, string id, string secret);
    Task DisableTwoFactor(TUser user, string code);
    
    Task<bool> VerifyOtpCode(string code);
}