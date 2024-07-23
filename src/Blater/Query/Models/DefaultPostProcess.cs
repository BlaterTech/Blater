using System.Collections.Generic;
using Blater.Query.Interfaces;

namespace Blater.Query.Models;

public class DefaultPostProcess : IPostProcess
{
    public object Execute<T>(IEnumerable<T?> items)
    {
        return items;
    }
}