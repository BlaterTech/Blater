using Blater.Enumerations;
using Blater.Query.Models;

namespace Blater.Query.Handlers;

public class ThenBySubPatternHandler : SubPatternHandlerBase
{
    public ThenBySubPatternHandler()
        : base(
            "ThenBy",
            "ThenByDescending")
    {
    }

    public override void Update(ProcessingLinqContext ctx)
    {
        var direction = ctx.CurrentMethod != null && ctx.CurrentMethod.Name.ComparedTo("ThenBy")
            ? OrderDirection.Ascending
            : OrderDirection.Descending;

        var order = new OrderBy
        {
            Direction = direction,
            Expression = ctx.CurrentMethod?.Expression.Arguments[1]
        };

        ctx.LinqQuery.AddOrderBy(order);
    }

    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        return false;
    }
}