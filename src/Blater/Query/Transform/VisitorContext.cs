using System.Linq.Expressions;
using Blater.Query.Models;
using Blater.Query.Visitors;

namespace Blater.Query.Transform;

public class VisitorContext(MongoQueryTransformVisitor visitor)
{
    private readonly Stack<IDictionary<string, object>?> _terms = new(5);

    public void Visit(Expression expression)
    {
        visitor.Visit(expression);
    }

    public IDictionary<string, object>? GetResult()
    {
        return _terms.Count == 0 ? null : _terms.Pop();
    }

    public void SetResult(DynamicDictionary? query)
    {
        if (query != null)
        {
            _terms.Push(query!);
        }
    }
}