using System.Linq.Expressions;

namespace Blater.Query.Transform.Handlers;

public class NameValue
{
    public Expression? Member { get; set; }
    public ConstantExpression? Constant { get; set; }
}