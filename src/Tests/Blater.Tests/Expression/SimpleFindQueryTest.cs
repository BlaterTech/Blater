using System.Linq.Expressions;
using Blater.JsonUtilities;
using Blater.Models;
using Blater.Query.Extensions;
using Blater.Query.Models;
using Blater.Query.Visitors;
using Blater.Utilities;

namespace Blater.Tests.Expression;

public class SimpleFindQueryTest
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
        var guid = SequentialGuidGenerator.NewGuid().ToString();
        
        Expression<Func<TestModel, bool>> predicate = x =>
            x.Description != null                    &&
            x.Description != "aa"                    &&
            (x.Id   == guid || x.Id   == guid)       &&
            (x.Year > 2020  || x.Year < 2024)        &&
            (x.Year >= 2021 || x.Year <= 2024)       &&
            x.Name == "Test"                         &&
            x.Description.Contains("Test")           &&
            x.StringList.Any(s => s == "Test")       &&
            x.StringList.All(s => s != string.Empty) &&
            x.StringList.In("A", "B")                &&
            x.Name.Regex(".*");
    
        var fields = new List<string> (){ "Name", "Year", "StringList" };
        var sortFields = new List<(string field,string direction)>() { ("Name", "asc") };
        
        //PreProcess
        var expression = PartialEvaluator.Eval(predicate);
        
        if (expression == null)
        {
            return;
        }
        
        var linqQuery = LinqVisitor.Eval(expression);
        
        var query = MongoQueryTransformVisitor.Eval(expression);
        
        Assert.NotNull(query);
    
        var expectedPretty = $$$$"""
    
                               """;
        
        var mongoQuery = new BlaterQuery()
        {
            //Index = index,
            Selector = query,
            Skip = linqQuery.Paging.Skip,
            Limit = linqQuery.Paging.Take,
            //Sort = orders.Counts == 0 ? null : orders
        };
        
        var json = mongoQuery.ToJson();
    
        var expected = expectedPretty.Replace("\n", "").Replace(" ", "");
        //Assert.Equal(expected, query);
    }
    
    [Fact]
    public void BestCaseScenario()
    {
        var id = Models.BlaterId.New("test");
        
        //
        var expected = $$$"""
                       {
                         "selector": {
                           "$and": [
                             {
                               "$and": [
                                 {
                                   "_id": {
                                     "$eq": "{{{id}}}"
                                   }
                                 },
                                 {
                                   "name": {
                                     "$eq": "Test"
                                   }
                                 }
                               ]
                             },
                             {
                               "description": {
                                 "$regex": "Test"
                               }
                             }
                           ]
                         },
                         "limit": 25,
                         "execution_stats": true
                       }
                       """;
        
        //
        
        Expression<Func<TestModel, bool>> predicate = x => x.Id == id && x.Name == "Test" && x.Description.Contains("Test");
        
        var query = predicate.ExpressionToBlaterQuery();
        
        Assert.NotNull(query);

        var json = query.ToJson();
        
        Assert.Equal(expected, json);
    }
    
    [Fact]
    public void BlaterId()
    {
        var blaterId = new BlaterId("test", Guid.NewGuid(), "1");
        
        //
        var expected = $$$"""
                          {
                            "selector": {
                              "_id": {
                                "$eq": "test:{{{blaterId.GuidValue}}}"
                              }
                            },
                            "limit": 25,
                            "execution_stats": true
                          }
                          """;
        
        //
        
        Expression<Func<TestModel, bool>> predicate = x => x.Id == blaterId;
        
        var query = predicate.ExpressionToBlaterQuery();
        
        Assert.NotNull(query);

        var json = query.ToJson();
        
        Assert.Equal(expected, json);
    }
}