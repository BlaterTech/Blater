using System.Linq.Expressions;
using Blater.Query;
using Blater.Query.Extensions;

namespace Blater.Tests.Expression;

public class SimpleFindQueryTest
{
    [Fact]
    public void EmptyQueryWithSelectFields()
    {
        var fields = new[] { "Name", "Year", "StringList" };
        
        Expression<Func<TestModel, bool>> predicate = x => true;
        var query = predicate.CompileToBlaterQuery(fields);
        
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
            x.StringList.All(s => s == "Test") &&
            x.StringList.In("A", "B")          &&
            x.Name.Regex(".*");
        
        var fields = new[] { "Name", "Year", "StringList" };
        
        var query = predicate.CompileToBlaterQuery(fields);
        
        var expectedPretty = $$$$"""
                               {
                                "selector":{
                                    "$and":[
                                        {"Description":{"$ne":null}},
                                        {"Description":{"$ne":"aa"}},
                                        {"$or":[
                                            {"Id":{"$eq":"{{{{guid}}}}"}},
                                            {"Id":{"$eq":"{{{{guid}}}}"}}
                                        ]},
                                        {"$or":[
                                            {"Year":{"$gt":2020}},
                                            {"Year":{"$lt":2024}}
                                        ]},
                                        {"$or":[
                                            {"Year":{"$gte":2021}},
                                            {"Year":{"$lte":2024}}
                                        ]},
                                        {"Name":{"$eq":"Test"}},
                                        {"Description":{"$regex":"Test"}},
                                        {"StringList":{"$elemMatch":{"$eq":"Test"}}},
                                        {"StringList":{"$allMatch":{"$eq":"Test"}}},
                                        {"StringList":{"$elemMatch":["A","B"]}},
                                        {"Name":{"$regex":".*"}}
                                    ]
                                },
                                "fields":["Name","Year","StringList"]
                               }
                               """;
        
        var expected = expectedPretty.Replace("\n", "").Replace(" ", "");
        Assert.Equal(expected, query);
    }
}