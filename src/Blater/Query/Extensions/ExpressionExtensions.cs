using System.Linq.Expressions;
using Blater.JsonUtilities;
using Blater.Query.Models;
using Blater.Query.Visitors;

namespace Blater.Query.Extensions;

public static class ExpressionExtensions
{
    
    /*public static string? ExpressionToMangoQuery<TModel, TReturn>(this Expression<Func<TModel, TReturn>> expression)
    {
        //PreProcess
        var expressionEvaluated = PartialEvaluator.Eval(expression);
        
        if (expressionEvaluated == null)
        {
            return null;
        }
        
        var linqQuery = LinqVisitor.Eval(expressionEvaluated);
        
        var query = MongoQueryTransformVisitor.Eval(expressionEvaluated);
        
        var json = query.ToJson();
        
        return json;
    }*/
    
    public static string ExpressionToMangoQuery(this Expression expression)
    {
        //PreProcess
        var expressionEvaluated = PartialEvaluator.Eval(expression);
        
        if (expressionEvaluated == null)
        {
            return "error";
        }
        
        var linqQuery = LinqVisitor.Eval(expressionEvaluated);
        
        var query = MongoQueryTransformVisitor.Eval(expressionEvaluated);
        
        var json = query.ToJson();
        
        return json ?? "error";
    }
    
    public static BlaterQuery? ExpressionToBlaterQuery(this Expression expression)
    {
        //PreProcess
        var expressionEvaluated = PartialEvaluator.Eval(expression);
        
        if (expressionEvaluated == null)
        {
            return null;
        }
        
        //var linqQuery = LinqVisitor.Eval(expressionEvaluated);
        
        var query = MongoQueryTransformVisitor.Eval(expressionEvaluated);
        
        var mongoQuery = new BlaterQuery()
        {
            //Index = index,
            Selector = query,
            //Skip = linqQuery.Paging.Skip,
            //Limit = linqQuery.Paging.Take,
            //Sort = orders.Count == 0 ? null : orders
        };
        
        var json = mongoQuery.ToJson();
        
        return mongoQuery;
    }
}