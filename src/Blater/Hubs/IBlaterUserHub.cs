﻿using Blater.Interfaces.BlaterUserStore;
using Blater.Models.User;

namespace Blater.Hubs;

public interface IBlaterUserHub : IBlaterUserEmailStore<BaseBlaterUser>,
                                  IBlaterUserLockoutStore<BaseBlaterUser>,
                                  IBlaterUserLoginStore<BaseBlaterUser>,
                                  IBlaterUserPasswordStore<BaseBlaterUser>,
                                  IBlaterUserSecurityStampStore<BaseBlaterUser>,
                                  IBlaterUserTwoFactorStore<BaseBlaterUser>
{
    
}