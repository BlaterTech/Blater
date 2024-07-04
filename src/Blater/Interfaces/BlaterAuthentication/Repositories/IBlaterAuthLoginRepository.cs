using Blater.Models.User;

namespace Blater.Interfaces.BlaterAuthentication.Repositories;

// Login History
// Device login
// Provider login

public interface IBlaterAuthLoginRepository
{
    Task<BlaterUser> LoginLocal(string email, string password);
    Task<BlaterUser> Register(string email, string password, string name);

    Task<BlaterUser> AddLogin(BlaterUser user, BlaterLoginInfo login);

    Task<BlaterUser> RemoveLogin(BlaterUser user, string loginProvider, string providerKey);

    Task<IReadOnlyList<BlaterLoginInfo>> GetLogins(BlaterId id);

    Task<BlaterUser> FindByLogin(string loginProvider, string providerKey);
}