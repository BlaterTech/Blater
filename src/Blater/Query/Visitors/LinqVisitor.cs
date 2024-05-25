using System.Linq.Expressions;
using Blater.Query.Handlers;
using Blater.Query.Interfaces;
using Blater.Query.Models;

namespace Blater.Query.Visitors;

public class LinqVisitor : ExpressionVisitor
{
    private readonly ProcessingLinqContext _ctx;
    
    private bool _indexQueryDefined;
    private readonly IEnumerable<ISubPatternHandler> _handlers;
    
    
    private LinqVisitor(ProcessingLinqContext ctx)
    {
        _ctx = ctx;
        _handlers = SubPatternRegistry.Handlers;
    }
    
    public static LinqQuery Eval(Expression expression)
    {
        var ctx = new ProcessingLinqContext(new LinqQuery(expression));
        var visitor = new LinqVisitor(ctx);
        visitor.Visit(expression);
        return ctx.LinqQuery;
    }
    
    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        //mainly interested in the left, also handle in reverse order
        var arg = node.Arguments[0];
        Visit(arg);
        
        //found a subQuery, for couchdb to handle, the rest will be in proc.
        if (_indexQueryDefined || _ctx.PreviousSubPatterns.Any(x => x.IndexQueryCompleted(_ctx)))
        {
            _ctx.LinqQuery.ParentQuery ??= new BlaterQueryExpression(node, _ctx.LinqQuery.FullQuery);
            return node;
        }
        
        _ctx.SetCurrentMethod(new Method(node));
        var handlers = _handlers.Where(x => x.CanHandle(_ctx)).ToList();
        
        //cannot handle with couchdb
        if (handlers.Count == 0)
        {
            _ctx.LinqQuery.ParentQuery = new BlaterQueryExpression(node, _ctx.LinqQuery.FullQuery);
            _indexQueryDefined = true;
            return node;
        }
        
        //handle the expression
        foreach (var handler in handlers)
        {
            handler.Update(_ctx);
        }
        
        _ctx.HandledBy(handlers);
        return node;
    }
}