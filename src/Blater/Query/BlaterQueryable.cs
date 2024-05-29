using System.Collections;
using System.Linq.Expressions;
using Blater.Query.Interfaces;

namespace Blater.Query;

public class BlaterQueryable<T> : IBlaterQueryable<T>, IQueryable, IEnumerable<T>, IEnumerable, IOrderedQueryable<T>, IOrderedQueryable where T : BaseDataModel
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