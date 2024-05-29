using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Blater.Query.Interfaces;
// ReSharper disable UnusedType.Global

namespace Blater.Query;

[SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix")]
public class BlaterQueryable<T> : IBlaterQueryable<T>, IQueryable, IEnumerable<T>, IEnumerable, IOrderedQueryable<T>, IOrderedQueryable where T : BaseDataModel
{
    public BlaterQueryable()
    {
        /*ElementType = elementType;
        Expression = expression;
        Provider = provider;*/
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public Type ElementType { get; } = default!;
    public Expression Expression { get; } = default!;
    public IQueryProvider Provider { get; }= default!;
}