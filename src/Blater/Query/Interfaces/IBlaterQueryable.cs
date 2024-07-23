using System;
using System.Collections.Generic;
using Blater.Models.Bases;
using Blater.Results;

namespace Blater.Query.Interfaces;

public interface IBlaterQueryable<T> where T : BaseDataModel
{
    public IBlaterQueryable<T> SetPartition(string partition);

    public IReadOnlyList<T> ToListAsync();

    public BlaterResult<T> GetResultAsync();
    IBlaterQueryable<T> Where(Func<T, bool> func);
    IBlaterQueryable<T> Take(int i);
    IBlaterQueryable<T> Skip(int i);
    IBlaterQueryable<T> Select(Func<T, object> func);
}