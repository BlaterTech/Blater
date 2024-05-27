using System.Collections;
using System.Linq.Expressions;

namespace Blater.Query;

public class BlaterQueryable<T> : IQueryable<T>, IQueryable, IEnumerable<T>, IEnumerable, IOrderedQueryable<T>, IOrderedQueryable
{
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public Type ElementType { get; }
    public Expression Expression { get; }
    public IQueryProvider Provider { get; }
}