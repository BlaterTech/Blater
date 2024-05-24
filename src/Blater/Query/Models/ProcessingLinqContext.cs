using Blater.Query.Interfaces;

namespace Blater.Query.Models;

public class ProcessingLinqContext(LinqQuery linqQuery)
{
    public IEnumerable<ISubPatternHandler> PreviousSubPatterns { get; private set; } = new List<ISubPatternHandler>();
    public Method? PreviousMethod { get; private set; }
    public Method? CurrentMethod { get; private set; }
    public LinqQuery LinqQuery { get; private set; } = linqQuery;
    //public Type BaseType { get; set; }
    
    public void SetCurrentMethod(Method? currentMethod)
    {
        if (CurrentMethod != null)
        {
            PreviousMethod = CurrentMethod;
        }
        CurrentMethod = currentMethod;
    }
    
    
    public void HandledBy(IEnumerable<ISubPatternHandler> pattens)
    {
        PreviousSubPatterns = pattens;
    }
}