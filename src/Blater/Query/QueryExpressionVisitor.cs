using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Text;
using FastExpressionCompiler;

namespace Blater.Query;

[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
public class QueryExpressionVisitor : ExpressionVisitor
{
    public QueryExpressionVisitor(StringBuilder stringBuilder)
    {
        
        StringBuilder = stringBuilder;
    }
    
    public string CompileToBlaterQuery(Expression expression, params string[] selectProperties)
    {
        //Start doc
        StringBuilder.Append('{');
        //Selector
        StringBuilder.Append(@"""selector"":{");
        Visit(expression);
        StringBuilder.Append('}');
        
        //Add select properties EX: "fields":["Name","Year","StringList"]
        StringBuilder.Append(',');
        StringBuilder.Append(@"""fields"":");
        StringBuilder.Append('[');
        for (var i = 0; i < selectProperties.Length; i++)
        {
            StringBuilder.Append('"');
            StringBuilder.Append(selectProperties[i]);
            StringBuilder.Append('"');
            if (i != selectProperties.Length - 1)
            {
                StringBuilder.Append(',');
            }
        }
        StringBuilder.Append(']');
        //End doc
        StringBuilder.Append('}');
        
        return StringBuilder.ToString();
    }
    
    public StringBuilder StringBuilder { get; }
}