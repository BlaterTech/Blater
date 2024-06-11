using Blater.Models.User;

namespace Blater.Hubs;

public interface IHelloWorldHub
{
    Task<List<string>> SendMessage(List<string> messages);
    string Ping(string message);
    Task<string> TestModel(string id, string testModel);
    //Task<string> TestModel( TestModel testModel);
    Task<bool> ReceivedMessage(BaseBlaterUser user);
}