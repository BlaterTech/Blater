using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

public interface IBlaterAuthTwoFactorStore
{
    Task<BlaterResult<BlaterUser>> EnableTwoFactor(BlaterUser user, string id, string secret);
    Task<BlaterResult<BlaterUser>> DisableTwoFactor(BlaterUser user, string code);
    Task<BlaterResult<bool>> VerifyOtpCode(string code);
}