using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace Blater.Query;

public class QueryExpressionVisitorPooledObjectPolicy(ObjectPool<StringBuilder> stringBuilderObjectPool) : IPooledObjectPolicy<QueryExpressionCompiler>
{
    public QueryExpressionCompiler Create()
    {
        var stringBuilder = stringBuilderObjectPool.Get();
        stringBuilder.Clear();
        
        
        return new QueryExpressionCompiler(stringBuilder);
    }
    
    public bool Return(QueryExpressionCompiler obj)
    {
        stringBuilderObjectPool.Return(obj.StringBuilder);
        return true;
    }
}