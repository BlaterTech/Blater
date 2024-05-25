using System.Linq.Expressions;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers;

public abstract class HandlerBase<T> : IHandler<T> where T : Expression
{
    public abstract void Handle(T expression, VisitorContext? context);
    
    public abstract bool CanHandle(T expression);
    
    public virtual Type HandleTypeOf => typeof (T);
    
    public virtual bool CanHandle(Expression expression)
    {
        return CanHandle((T)expression);
    }
    
    
    public virtual void Handle(Expression expression, VisitorContext? context)
    {
        Handle((T)expression, context);
    }
    
    protected virtual DynamicDictionary? CreateQuery(Expression? left, DynamicDictionary? right, VisitorContext? context)
    {
        var evaluator = new NameEvaluator(context, right);
        evaluator.Visit(left);
        return evaluator.Query;
    }
}