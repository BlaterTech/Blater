﻿using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

public interface IBlaterAuthTwoFactorStore
{
    Task<BlaterUser> EnableTwoFactor(BlaterUser user, string id, string secret);
    Task<BlaterUser> DisableTwoFactor(BlaterUser user, string code);
    Task<bool> VerifyOtpCode(string code);
}