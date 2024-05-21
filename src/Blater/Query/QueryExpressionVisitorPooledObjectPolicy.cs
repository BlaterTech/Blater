using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace Blater.Query;

public class QueryExpressionVisitorPooledObjectPolicy(ObjectPool<StringBuilder> stringBuilderObjectPool) : IPooledObjectPolicy<QueryExpressionVisitor>
{
    public QueryExpressionVisitor Create()
    {
        var stringBuilder = stringBuilderObjectPool.Get();
        stringBuilder.Clear();
        return new QueryExpressionVisitor(stringBuilder);
    }
    
    public bool Return(QueryExpressionVisitor obj)
    {
        stringBuilderObjectPool.Return(obj.StringBuilder);
        return true;
    }
}