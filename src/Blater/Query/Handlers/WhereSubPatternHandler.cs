using Blater.Query.Models;

namespace Blater.Query.Handlers;

public class WhereSubPatternHandler() : SubPatternHandlerBase(objects => objects.Where(x => true))
{
    public override void Update(ProcessingLinqContext ctx)
    {
        ctx.LinqQuery.AddWhereClause(ctx.CurrentMethod?.Expression.Arguments[1]);
    }
    
    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        return false;
    }
}