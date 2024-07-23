using System;
using Blater.Query.Models;

namespace Blater.Query.Handlers;

public class AllSubPatternHandler() : SubPatternHandlerBase(objects => objects.All(p => true))
{
    public override void Update(ProcessingLinqContext ctx)
    {
        throw new NotImplementedException();
    }

    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        return false;
    }
}