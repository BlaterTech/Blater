using System.Linq.Expressions;
using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace Blater.Query;

public static class QueryCompiler
{
    internal static readonly ObjectPool<StringBuilder> StringBuilderPool = new DefaultObjectPoolProvider().CreateStringBuilderPool();
    
    internal static readonly ObjectPool<QueryExpressionCompiler> QueryExpressionVisitor =
        new DefaultObjectPool<QueryExpressionCompiler>(new QueryExpressionVisitorPooledObjectPolicy(StringBuilderPool));
    
    public static string CompileToBlaterQuery(this Expression expression, List<string> selectProperties, List<string> sortProperties)
    {
        var queryExpressionVisitor = QueryExpressionVisitor.Get();
        try
        {
            queryExpressionVisitor.CompileToBlaterQuery(expression, selectProperties, sortProperties);
            return queryExpressionVisitor.StringBuilder.ToString();
        }
        finally
        {
            QueryExpressionVisitor.Return(queryExpressionVisitor);
        }
    }
}