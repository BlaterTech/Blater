using Blater.Models.User;
using Blater.Results;

namespace Blater.Interfaces.BlaterAuthentication.Stores;

// Login History
// Device login
// Provider login

public interface IBlaterAuthLoginStore
{
    Task<BlaterResult<BlaterUser>> LoginLocal(string email, string password);

    Task<BlaterResult<BlaterUser>> Register(string email, string password, string name);

    Task<BlaterResult<BlaterUser>> AddLogin(BlaterUser user, BlaterLoginInfo login);

    Task<BlaterResult<BlaterUser>> RemoveLogin(BlaterUser user, string loginProvider, string providerKey);

    Task<BlaterResult<IReadOnlyList<BlaterLoginInfo>>> GetLogins(Ulid id);

    Task<BlaterResult<BlaterUser>> FindByLogin(string loginProvider, string providerKey);
}