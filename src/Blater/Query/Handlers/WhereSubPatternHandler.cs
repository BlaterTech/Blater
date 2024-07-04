using Blater.Query.Models;

namespace Blater.Query.Handlers;

public class WhereSubPatternHandler() : SubPatternHandlerBase(objects => objects.Where(x => true))
{
    public override void Update(ProcessingLinqContext ctx)
    {
        var clause = ctx.CurrentMethod?.Expression.Arguments[1];
        if (clause == null)
        {
            return;
        }

        ctx.LinqQuery.AddWhereClause(clause);
    }

    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        return false;
    }
}