using Blater.Interfaces;
using Blater.Models.User;

namespace Blater.Hubs;

public interface IBlaterAuthHub : IBlaterAuthStore<BaseBlaterUser>
{
}