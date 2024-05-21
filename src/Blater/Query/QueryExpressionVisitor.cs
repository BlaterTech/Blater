using System.Linq.Expressions;
using System.Text;

namespace Blater.Query;

public class QueryExpressionVisitor : ExpressionVisitor
{
    public QueryExpressionVisitor(StringBuilder stringBuilder)
    {
        
        StringBuilder = stringBuilder;
    }
    
    public StringBuilder StringBuilder { get; }
    
    public override Expression? Visit(Expression? node)
    {
        StringBuilder.Append('{');
        return base.Visit(node);
    }
}