using System.Linq.Expressions;
using Blater.Enumerations;

namespace Blater.Query.Models;

public class OrderBy
{
    public Expression? Expression { get; set; }
    public OrderDirection Direction { get; set; }
}