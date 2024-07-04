using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Handlers;

//objects => objects.TakeWhile(p => true)
[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
public class TakeSubPatternHandler() : SubPatternHandlerBase(objects => objects.Take(1))
{
    //skip, take, distinct, single, count, any
    private static readonly HashSet<string> AllowedNextStep = ["take", "distinct", "single", "count", "any"];


    public override void Update(ProcessingLinqContext ctx)
    {
        if (ctx.CurrentMethod == null)
        {
            return;
        }

        var exp = (ConstantExpression)ctx.CurrentMethod.Expression.Arguments[1];
        ctx.LinqQuery.Paging.Take = Convert.ToInt64(exp.Value);
    }

    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        if (ctx.CurrentMethod == null)
        {
            return false;
        }

        return !AllowedNextStep.Contains(ctx.CurrentMethod.Name.ToLower());
    }
}