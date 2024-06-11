using Blater.Models.User;

namespace Blater;

public class TestModel : BaseBlaterUser
{
    public TestModel()
    {
        Id = BlaterId.New("user");
    }
}