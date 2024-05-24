using System.Linq.Expressions;
using Blater.Query.Models;
using Blater.Query.Visitors;

namespace Blater.Query.Transform;

public class VisitorContext
{
    private readonly Stack<IDictionary<string, object>?> _terms = new(5);
    private readonly MongoQueryTransformVisitor _visitor;
    
    
    public VisitorContext(MongoQueryTransformVisitor visitor)
    {
        _visitor = visitor;
    }
    
    public void Visit(Expression expression)
    {
        _visitor.Visit(expression);
    }
    
    
    public IDictionary<string, object>? GetResult()
    {
        return _terms.Pop();
    }
    
    public void SetResult(DynamicDictionary? query)
    {
        if (query != null)
        {
            _terms.Push(query!);
        }
    }
}