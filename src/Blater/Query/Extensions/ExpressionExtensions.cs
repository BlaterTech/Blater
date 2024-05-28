using Blater.JsonUtilities;
using Blater.Query.Models;
using Blater.Query.Visitors;

using System.Linq.Expressions;

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

    public static IDictionary<string, object> ExpressionToMangoQuery(this Expression expression)
    {
        //PreProcess
        var expressionEvaluated = PartialEvaluator.Eval(expression);

        if (expressionEvaluated == null)
        {
            return new Dictionary<string, object>();
        }

        var query = MongoQueryTransformVisitor.Eval(expressionEvaluated);

        return query ?? new Dictionary<string, object>();
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

        _ = mongoQuery.ToJson();

        return mongoQuery;
    }
}