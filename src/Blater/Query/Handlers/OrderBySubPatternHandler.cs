using Blater.Enumerations;
using Blater.Query.Models;

namespace Blater.Query.Handlers;

public class OrderBySubPatternHandler : SubPatternHandlerBase
{
    public OrderBySubPatternHandler()
        : base(
            objects => objects.OrderBy(p => p),
            objects => objects.OrderByDescending(p => p))
    {
    }
    
    public override void Update(ProcessingLinqContext ctx)
    {
        if (ctx.CurrentMethod == null)
        {
            return;
        }
        
        var direction = ctx.CurrentMethod.Name.ComparedTo("OrderBy")
            ? OrderDirection.Ascending
            : OrderDirection.Descending;
        
        var order = new OrderBy
        {
            Direction = direction,
            Expression = ctx.CurrentMethod.Expression.Arguments[1]
        };
        
        ctx.LinqQuery.AddOrderBy(order);
    }
    
    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        return false;
    }
}