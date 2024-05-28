using System.Linq.Expressions;
using Blater.Query.Helpers;
using Blater.Query.Interfaces;
using Blater.Query.Models;

namespace Blater.Query.Handlers;

public abstract class SubPatternHandlerBase : ISubPatternHandler
{
    protected static readonly ReflectionHelper<IEnumerable<object>> ReflectionHelper = new();
    protected Func<MethodCallExpression, bool> Supported { get; private set; }
    
    protected SubPatternHandlerBase(Expression<Func<IEnumerable<object>, object>> expression)
    {
        var methodName = ReflectionHelper.GetSupportedMethod(expression).Name;
        Supported = exp => exp.Method.Name.ComparedTo(methodName);
    }
    
    protected SubPatternHandlerBase(params Expression<Func<IEnumerable<object>, object?>?>[]? expressions)
    {
        if (expressions == null)
        {
            Supported = exp => false;
            return;
        }
        
        var names = expressions.Select(expression =>
        {
            ArgumentNullException.ThrowIfNull(expression);
            return ReflectionHelper.GetSupportedMethod(expression!).Name;
        }).ToList();
        
        Supported = exp =>
        {
            var name = exp.Method.Name;
            return names.Any(name.ComparedTo);
        };
    }
    
    protected SubPatternHandlerBase(params string[] methods)
    {
        Supported = exp =>
        {
            var name = exp.Method.Name;
            return methods.Any(name.ComparedTo);
        };
        
    }
    
    public bool CanHandle(ProcessingLinqContext ctx)
    {
        return ctx.CurrentMethod != null && Supported(ctx.CurrentMethod.Expression);
    }
    
    public abstract void Update(ProcessingLinqContext ctx);
    
    public abstract bool IndexQueryCompleted(ProcessingLinqContext ctx);
}