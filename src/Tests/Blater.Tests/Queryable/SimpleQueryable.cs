using System.Linq.Expressions;
using Blater.JsonUtilities;
using Blater.Models;
using Blater.Query.Extensions;
using Blater.Query.Interfaces;
using Blater.Query.Models;
using Blater.Query.Visitors;
using Blater.Utilities;

namespace Blater.Tests.Queryable;

public class SimpleQueryable
{
    /*[Fact]
    public void EmptyQueryWithSelectFields()
    {
        var fields = new List<string> (){ "Name", "Year", "StringList" };
        var sortFields = new List<(string field,string direction)>() { ("Name", "asc") };
        
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
    }*/
    
    /*[Fact]
    public void Test1()
    {
        var guid = Guid.NewShortId();
        
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
        var sortFields = new List<(string field,string direction)>() { ("Name", "asc") };
        
        var query = predicate.CompileToBlaterQuery(fields, sortFields);
        
        var expectedPretty = $$$$"""
                               
                               """;
        
        var expected = expectedPretty.Replace("\n", "").Replace(" ", "");
        Assert.Equal(expected, query);
    }*/
    
    [Fact]
    public void WorstCaseScenario()
    {
        IBlaterQueryable<TestModel> queryable = default!;
        
        var result = queryable
                    .SetPartition("asda")
                    .Where(x => x.Description.Contains("Test"))
                    .Take(1)
                    .Skip(1)
                    .Select(x => x.Id);
        
    }
}