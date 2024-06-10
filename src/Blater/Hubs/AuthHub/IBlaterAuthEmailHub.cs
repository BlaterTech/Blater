using Blater.Interfaces.BlaterAuthentication;
using Blater.Models.User;

namespace Blater.Hubs.AuthHub;

public interface IBlaterAuthEmailHub : IBlaterAuthEmailStore<BaseBlaterUser>
{
    
}