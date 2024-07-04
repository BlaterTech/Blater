using Blater.Query.Models;

namespace Blater.Query.Handlers;

public class AnySubPatternHandler() : SubPatternHandlerBase(objects => objects.Any())
{
    public override void Update(ProcessingLinqContext ctx)
    {
        throw new NotImplementedException();
    }

    public override bool IndexQueryCompleted(ProcessingLinqContext ctx)
    {
        return true;
    }
}