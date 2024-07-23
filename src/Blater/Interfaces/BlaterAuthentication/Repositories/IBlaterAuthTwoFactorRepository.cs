using System.Threading.Tasks;
using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthTwoFactorRepository
{
    Task<BlaterUser> EnableTwoFactor(BlaterUser user, string id, string secret);
    Task<BlaterUser> DisableTwoFactor(BlaterUser user, string code);
    Task<bool> VerifyOtpCode(string code);
}