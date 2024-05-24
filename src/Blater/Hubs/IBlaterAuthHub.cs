using Blater.Interfaces;

namespace Blater.Hubs;

public interface IBlaterAuthHub : IBlaterAuth
{
    Task OnlyHubMethod();
}