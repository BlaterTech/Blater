using Blater.Utilities;

namespace Blater.Tests;

public class SequentialIdTests
{
    [Fact]
    public void GenerateALotIds()
    {
        const int iterations = 1_000;
        var ids = new List<Guid>();
        var randomIds = new Guid[iterations];
        for (var i = 0; i < iterations; i++)
        {
            var id = SequentialGuidGenerator.NewGuid();
            ids.Add(id);
            randomIds[i] = id;
        }
        var shuffledArray = randomIds.OrderBy(x => Random.Shared.Next()).ToArray();
        
        var orderedIds = shuffledArray.OrderBy(x => x).ToList();
        
        Assert.Equivalent(ids, orderedIds);
    }
}