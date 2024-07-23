using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Blater.Query.Interfaces;
using Blater.Query.Models;

namespace Blater.Query.Handlers;

[SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity")]
public class FirstSubPatternHandler : SubPatternHandlerBase
{
    public FirstSubPatternHandler()
        : base(objects => objects.First(), objects => objects.FirstOrDefault())
    {
    }

    public override void Update(ProcessingLinqContext ctx)
    {
        if (ctx.CurrentMethod == null)
        {
            return;
        }


        var args = ctx.CurrentMethod.Expression.Arguments;
        if (args.Count == 2)
        {
            ctx.LinqQuery.AddWhereClause(args[1]);
        }

        ctx.LinqQuery.PostProcess = ctx.CurrentMethod.Expression.Method.Name.Contains("Default")
            ? new FirstOrDefaultPostProcess()
            : new FirstPostProcess();

        ctx.LinqQuery.Paging.Take = 1;
    }

    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        return true;
    }


    private class FirstOrDefaultPostProcess : IPostProcess
    {
        public object? Execute<T>(IEnumerable<T?> items)
        {
            return items.FirstOrDefault();
        }
    }

    private class FirstPostProcess : IPostProcess
    {
        public object? Execute<T>(IEnumerable<T?> items)
        {
            return items.First();
        }
    }
}