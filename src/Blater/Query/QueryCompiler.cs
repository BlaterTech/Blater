using System.Linq.Expressions;
using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace Blater.Query;

public static class QueryCompiler
{
    internal static readonly ObjectPool<StringBuilder> StringBuilderPool = new DefaultObjectPoolProvider().CreateStringBuilderPool();
    
    internal static readonly ObjectPool<QueryExpressionVisitor> QueryExpressionVisitor =
        new DefaultObjectPool<QueryExpressionVisitor>(new QueryExpressionVisitorPooledObjectPolicy(StringBuilderPool));
    
    public static string CompileToBlaterQuery(this Expression expression, params string[] selectProperties)
    {
        var queryExpressionVisitor = QueryExpressionVisitor.Get();
        try
        {
            queryExpressionVisitor.CompileToBlaterQuery(expression, selectProperties);
            return queryExpressionVisitor.StringBuilder.ToString();
        }
        finally
        {
            QueryExpressionVisitor.Return(queryExpressionVisitor);
        }
    }
}