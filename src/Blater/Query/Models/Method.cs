using System.Linq.Expressions;

namespace Blater.Query.Models
{
    public class Method(MethodCallExpression expression)
    {
        public string Name { get; set; } = expression.Method.Name;
        public MethodCallExpression Expression { get; set; } = expression;
    }
}