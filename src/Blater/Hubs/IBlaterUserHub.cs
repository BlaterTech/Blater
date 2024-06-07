using Blater.Interfaces.BlaterUserStore;

namespace Blater.Hubs;

public interface IBlaterUserHub : IBlaterUserEmailStore<BlaterUser>,
                                  IBlaterUserLockoutStore<BlaterUser>,
                                  IBlaterUserLoginStore<BlaterUser>,
                                  IBlaterUserPasswordStore<BlaterUser>,
                                  IBlaterUserSecurityStampStore<BlaterUser>,
                                  IBlaterUserTwoFactorStore<BlaterUser>
{
    
}