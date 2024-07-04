using System.Diagnostics.CodeAnalysis;
using Blater.Query.Interfaces;
using Blater.Query.Models;

namespace Blater.Query.Handlers;

[SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity")]
public class SingleSubPatternHandler : SubPatternHandlerBase
{
    public SingleSubPatternHandler()
        : base(objects => objects.Single(), objects => objects.SingleOrDefault())
    {
    }

    public override void Update(ProcessingLinqContext ctx)
    {
        if (ctx.CurrentMethod?.Expression.Arguments == null)
        {
            return;
        }

        var args = ctx.CurrentMethod.Expression.Arguments;
        if (args.Count == 2)
        {
            ctx.LinqQuery.AddWhereClause(args[1]);
        }

        ctx.LinqQuery.PostProcess = ctx.CurrentMethod.Expression.Method.Name.Contains("Default")
            ? new SingleOrDefaultPostProcess()
            : new SinglePostProcess();

        //note this take 2 is to ensure we have a SINGLE returned.
        ctx.LinqQuery.Paging.Take = 2;
    }

    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        return true;
    }


    private class SingleOrDefaultPostProcess : IPostProcess
    {
        public object? Execute<T>(IEnumerable<T?> items)
        {
            return items.SingleOrDefault();
        }
    }

    private class SinglePostProcess : IPostProcess
    {
        public object? Execute<T>(IEnumerable<T?> items)
        {
            return items.Single();
        }
    }
}