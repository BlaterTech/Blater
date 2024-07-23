using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Handlers;

//cannot support this one
//objects => objects.SkipWhile(p => true)
[SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
public class SkipSubPatternHandler() : SubPatternHandlerBase(objects => objects.Skip(1))
{
    //skip, take, distinct, single, count, any
    private static readonly List<string> AllowedNextStep = ["skip", "take", "distinct", "single", "count", "any"];


    public override void Update(ProcessingLinqContext ctx)
    {
        if (ctx.CurrentMethod == null)
        {
            return;
        }

        var exp = (ConstantExpression)ctx.CurrentMethod.Expression.Arguments[1];
        ctx.LinqQuery.Paging.Skip += Convert.ToInt64(exp.Value);
    }

    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        if (ctx.CurrentMethod == null)
        {
            return false;
        }

        return !AllowedNextStep.Any(x => x.ComparedTo(ctx.CurrentMethod.Name));
    }
}