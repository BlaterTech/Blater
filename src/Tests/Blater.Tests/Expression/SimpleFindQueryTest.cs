using System.Linq.Expressions;
using Blater.Query;
using Blater.Query.Extensions;

namespace Blater.Tests.Expression;

public class SimpleFindQueryTest
{
    [Fact]
    public void EmptyQueryWithSelectFields()
    {
        var fields = new List<string> (){ "Name", "Year", "StringList" };
        var sortFields = new List<string> (){ "Name" };
        
        Expression<Func<TestModel, bool>> predicate = x => true;
        var query = predicate.CompileToBlaterQuery(fields, sortFields);
        
        var expected = """
                       {
                        "selector":{},
                        "fields":["Name","Year","StringList"]
                       }
                       """;
        
        var expectedPretty = expected.Replace("\n", "").Replace("\r", "").Replace(" ", "");
        Assert.Equal(expectedPretty, query);
    }
    
    [Fact]
    public void Test1()
    {
        var guid = Guid.NewGuid();
        
        Expression<Func<TestModel, bool>> predicate = x =>
            x.Description != null              &&
            x.Description != "aa"              &&
            (x.Id   == guid || x.Id   == guid) &&
            (x.Year > 2020  || x.Year < 2024)  &&
            (x.Year >= 2021 || x.Year <= 2024) &&
            x.Name == "Test"                   &&
            x.Description.Contains("Test")     &&
            x.StringList.Any(s => s == "Test") &&
            x.StringList.All(s => s != string.Empty) &&
            x.StringList.In("A", "B")          &&
            x.Name.Regex(".*");
        
        var fields = new List<string> (){ "Name", "Year", "StringList" };
        var sortFields = new List<string> (){ "Name" };
        
        var query = predicate.CompileToBlaterQuery(fields, sortFields);
        
        var expectedPretty = $$$$"""
                               
                               """;
        
        var expected = expectedPretty.Replace("\n", "").Replace(" ", "");
        Assert.Equal(expected, query);
    }
}