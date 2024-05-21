using System.Linq.Expressions;
using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace Blater.Query;

public class QueryExpressionVisitor(StringBuilder stringBuilder) : ExpressionVisitor
{
    public StringBuilder StringBuilder { get; } = stringBuilder;
    
    public override Expression? Visit(Expression? node)
    {
        
        
        return base.Visit(node);
    }
}