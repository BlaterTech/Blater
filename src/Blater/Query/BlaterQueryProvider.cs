using System.Linq.Expressions;
using Blater.Query.Interfaces;

namespace Blater.Query;

public class BlaterQueryProvider : IQueryProvider, IQueryText
{
    public IQueryable CreateQuery(Expression expression)
    {
        throw new NotImplementedException();
    }
    
    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        throw new NotImplementedException();
    }
    
    public object? Execute(Expression expression)
    {
        throw new NotImplementedException();
    }
    
    public TResult Execute<TResult>(Expression expression)
    {
        throw new NotImplementedException();
    }
    
    public string GetQueryText(Expression expression)
    {
        throw new NotImplementedException();
    }
}