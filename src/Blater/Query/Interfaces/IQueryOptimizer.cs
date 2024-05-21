using System.Linq.Expressions;

namespace Blater.Query.Interfaces;

public interface IQueryOptimizer
{
    Expression Execute(Expression expression);
}