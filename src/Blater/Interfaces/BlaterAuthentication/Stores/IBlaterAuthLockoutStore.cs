using System;
using System.Threading.Tasks;
using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

//TODO ban* user

public interface IBlaterAuthLockoutStore
{
    Task<BlaterResult<BlaterUser>> SetLockoutEndDate(BlaterUser user, DateTimeOffset? lockoutEnd);

    Task<BlaterResult<int>> IncrementAccessFailedCount(BlaterUser user);

    Task<BlaterResult<BlaterUser>> ResetAccessFailedCount(BlaterUser user);

    Task<BlaterResult<BlaterUser>> SetLockoutEnabled(BlaterUser user, bool enabled);
}