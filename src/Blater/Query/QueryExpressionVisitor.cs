using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace Blater.Query;

public class QueryExpressionVisitor : ExpressionVisitor
{
    
    
    public QueryExpressionVisitor(StringBuilder stringBuilder)
    {
        
        StringBuilder = stringBuilder;
    }
    
    public StringBuilder StringBuilder { get; }

}