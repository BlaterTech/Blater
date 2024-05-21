using System.Linq.Expressions;
using Blater.Query;

namespace Blater.Tests.Expression;

public class SimpleFindQueryTest
{
    [Fact]
    public void Test1()
    {
        var guid = Guid.NewGuid();
        Expression<Func<TestModel, bool>> predicate = x => x.Id == guid;
        var query = predicate.CompileToBlaterQuery();
        
        var expected = $"{{\"selector\":{{\"Id\":\"{guid}\"}}}}";
        Assert.Equal(expected, query);
    }
}