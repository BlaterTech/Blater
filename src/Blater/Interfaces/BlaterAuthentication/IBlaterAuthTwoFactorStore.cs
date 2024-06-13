using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication;

public interface IBlaterAuthTwoFactorStore<in TUser>  where TUser : BaseBlaterUser
{
    Task EnableTwoFactor(TUser user, string id, string secret);
    Task DisableTwoFactor(TUser user, string code);
    Task<BlaterResult<bool>> VerifyOtpCode(string code);
}