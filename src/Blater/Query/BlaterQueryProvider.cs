/*using System.Linq.Expressions;
using System.Reflection;
using Blater.Enumerations;
using Blater.Query.Extensions;
using Blater.Query.Helpers;
using Blater.Query.Interfaces;
using Blater.Query.Models;
using Blater.Query.Transform;
using Blater.Query.Visitors;
using FastExpressionCompiler;
using FastGenericNew;

namespace Blater.Query;

public class BlaterQueryProvider<T> : IQueryProvider, IQueryText where T : class
{
    public IQueryable CreateQuery(Expression expression)
    {

        var elementType = TypeHelper.GetElementType(expression.Type);
        if (elementType == null)
        {
            throw new InvalidOperationException("Could not get element type");
        }
        
        try
        {
            var queryableGenericType = typeof(BlaterQueryable<>).MakeGenericType(elementType);
            
            var instance = Activator.CreateInstance(queryableGenericType, [this, expression]);
            
            if (instance == null)
            {
                throw new InvalidOperationException("Could not create new instance of BlaterQueryable");
            }
            
            return (IQueryable)instance;
        }
        catch (Exception tie)
        {
            //TODO logging
            Console.WriteLine(tie);
            throw;
        }
    }
    
    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        return new BlaterQueryable<TElement>(expression, this);
    }
    
    public object? Execute(Expression expression)
    {
        
        expression = PartialEvaluator.Eval(expression) ?? throw new InvalidOperationException("Could not evaluate expression");
        
        var linqQuery = LinqVisitor.Eval(expression);
        
        //TODO: Add TypeFilter here
        
        var clauses = new List<IDictionary<string, object>>();
        //TODO add type clause here: clauses.Add(typesQuery);
        
        foreach (var linqQueryWhereClause in linqQuery.WhereClauses)
        {
            var partialQuery = MongoQueryTransformVisitor.Eval(linqQueryWhereClause);
            if (partialQuery == null)
            {
                Console.WriteLine("Partial query is null");
                continue;
            }
            clauses.Add(partialQuery);
        }
        
        //Add the clauses to the query, if more than one we add an $and
        IDictionary<string, object> query;
        if (clauses.Counts == 1 && !linqQuery.Ordering.Any())
        {
            query = clauses.First();
        }
        else
        {
            query = new DynamicDictionary
            {
                { "$and", clauses }
            }!;
        }
        
        //Sort(OrderBy)
        var orderHandler = new OrderByHandler();
        var orders = new List<IDictionary<string, OrderDirection>>();
        foreach (var orderBy in linqQuery.Ordering)
        {
            var order = new Dictionary<string, OrderDirection>();
            var name = orderHandler.GetMemberName((MemberExpression)((LambdaExpression)((UnaryExpression)orderBy.Expression!).Operand).Body);
            var or = orderBy.Direction == OrderDirection.Ascending ? OrderDirection.Ascending : OrderDirection.Descending;
            order.Add(name, or);
            orders.Add(order);
            
            //add the name to the selector.
            var sortSelector = new DynamicDictionary { { name, new DynamicDictionary { { "$gt", null } } } };
            clauses.Add(sortSelector!);
        }
        
        //Index
        //object index = null;
        //if (_index != null && _index.Any())
        //{
        //    index = _index.Counts() == 1 ? (object)_index.First() : (object)_index;
        //}
        
        //Construct the final query object
        var blaterQuery = new BlaterQuery
        {
            //Index = index,
            Selector = query,
            Skip = linqQuery.Paging.Skip,
            Limit = linqQuery.Paging.Take,
            Sort = orders.Counts == 0 ? null : orders
        };
        
        //TODO: Add PostProcess here
        //Call the Database Client here
        //var collection = _session.Query<T>(mongoQuery);
        var resultList = new List<T>();
        if (linqQuery.ParentQuery == null)
        {
            return linqQuery.PostProcess.Execute(resultList);
        }
        
        //we have only run some of the query, this will setup the rest
        linqQuery.ParentQuery.RewriteSource(resultList);
        var exp = linqQuery.ParentQuery.Expression;
        
        if (exp == null)
        {
            throw new InvalidOperationException("Could not evaluate expression");
        }
        
        var result = Expression.Lambda(exp).CompileFast().DynamicInvoke();
        
        if(result == null)
        {
            throw new InvalidOperationException("Could not evaluate expression");
        }
        
        return result;
    }
    
    public TResult Execute<TResult>(Expression expression)
    {
        var resultObject = Execute(expression);
        
        if (resultObject is TResult result)
        {
            return result;
        }
        
        return default!;
    }
    
    public string GetQueryText(Expression expression)
    {
        return expression.ExpressionToMangoQuery();
    }
}*/