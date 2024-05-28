using Blater.JsonUtilities;
using Blater.Models;

namespace Blater.Tests.JsonTests;

public class JsonBlaterIdTests
{
    [Fact]
    public void CreateBlaterId()
    {
        var blaterId = new BlaterId("123", Guid.NewGuid(), "123");
        var model = new JsonBlaterModel()
        {
            Id = blaterId,
            ObrenoFicameapressandodemais = "asdasdas",
            ObrenoFicameapressandodemais2 = "asdasdas",
            ObrenoFicameapressandodemais3 = "asdasdas",
            ObrenoFicameapressandodemais4 = "asdasdas",
            ObrenoFicameapressandodemais5 = "asdasdas",
        };
        var json = model.ToJson();
        var result = json.FromJson<JsonBlaterModel>();
        Assert.Equivalent(model, result);
    }
}