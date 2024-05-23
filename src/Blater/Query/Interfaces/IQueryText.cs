using System.Linq.Expressions;

namespace Blater.Query.Interfaces;

public interface IQueryText
{
    string GetQueryText(Expression expression);
}