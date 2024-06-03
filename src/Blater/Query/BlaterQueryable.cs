using Blater.Query.Interfaces;

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Blater.Resullts;

// ReSharper disable UnusedType.Global

namespace Blater.Query;

[SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix")]
//TODO Properly use IQueryProvider and IQueryable
public class BlaterQueryable<T> : IBlaterQueryable<T> where T : BaseDataModel
{
    public BlaterQueryable()
    {
        /*ElementType = elementType;
        Expression = expression;
        Provider = provider;*/
    }
    
    internal string? Partition { get; set; }
    
    public IBlaterQueryable<T> SetPartition(string partition)
    {
        Partition = partition;
        return this;
    }
    
    public IBlaterQueryable<T> Where(Func<T, bool> func)
    {
        return this;
    }
    
    public IBlaterQueryable<T> Take(int i)
    {
        return this;
    }
    
    public IBlaterQueryable<T> Skip(int i)
    {
        return this;
    }
    
    public IBlaterQueryable<T> Select(Func<T, object> func)
    {
        return this;
    }
    
    public Type ElementType { get; } = default!;
    public Expression Expression { get; } = default!;
    public IQueryProvider Provider { get; } = default!;
    
    public IReadOnlyList<T> ToListAsync()
    {
        throw new NotImplementedException();
    }
    
    public BlaterResult<T> GetResultAsync()
    {
        throw new NotImplementedException();
    }
}