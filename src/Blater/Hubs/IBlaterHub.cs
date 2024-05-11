using Blater.Interfaces;

namespace Blater.Hubs;

public interface IBlaterHub : IBlaterAuth, IBlaterQueue, IBlaterDatabaseHub, IBlaterKeyValueHub;