using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthTwoFactorStore
{
    Task EnableTwoFactor(BlaterUser user, string id, string secret);
    Task DisableTwoFactor(BlaterUser user, string code);
    Task<BlaterResult<bool>> VerifyOtpCode(string code);
}