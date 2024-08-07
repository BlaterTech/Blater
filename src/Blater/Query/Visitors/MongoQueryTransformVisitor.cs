using System.Linq.Expressions;
using Blater.Query.Transform;
using Blater.Query.Transform.Handlers;

namespace Blater.Query.Visitors;

public class MongoQueryTransformVisitor : ExpressionVisitor
{
    private readonly Dictionary<Type, List<IHandler>?> _handlers = HandlerRegistry.Handlers;
    public VisitorContext? Context { get; set; }

    public static IDictionary<string, object>? Eval(Expression expression)
    {
        var visitor = new MongoQueryTransformVisitor();
        var context = new VisitorContext(visitor);
        visitor.Context = context;

        visitor.Visit(expression);

        return context.GetResult();
    }

    public override Expression Visit(Expression? node)
    {
        return Handle(node, base.Visit!);
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        return Handle(node, base.VisitBinary);
    }

    protected override Expression VisitBlock(BlockExpression node)
    {
        return Handle(node, base.VisitBlock);
    }

    protected override Expression VisitConditional(ConditionalExpression node)
    {
        return Handle(node, base.VisitConditional);
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        return Handle(node, base.VisitConstant);
    }

    protected override Expression VisitDebugInfo(DebugInfoExpression node)
    {
        return Handle(node, base.VisitDebugInfo);
    }

    protected override Expression VisitDefault(DefaultExpression node)
    {
        return Handle(node, base.VisitDefault);
    }

//  protected override Expression VisitDynamic(DynamicExpression node)
//  {
//      return Handle(node, base.VisitDynamic);
//  }

    protected override Expression VisitExtension(Expression node)
    {
        return Handle(node, base.VisitExtension);
    }

    protected override Expression VisitGoto(GotoExpression node)
    {
        return Handle(node, base.VisitGoto);
    }

    protected override Expression VisitIndex(IndexExpression node)
    {
        return Handle(node, base.VisitIndex);
    }

    protected override Expression VisitInvocation(InvocationExpression node)
    {
        return Handle(node, base.VisitInvocation);
    }

    protected override Expression VisitLabel(LabelExpression node)
    {
        return Handle(node, base.VisitLabel);
    }

    protected override Expression VisitListInit(ListInitExpression node)
    {
        return Handle(node, base.VisitListInit);
    }

    protected override Expression VisitLoop(LoopExpression node)
    {
        return Handle(node, base.VisitLoop);
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        return Handle(node, base.VisitMember);
    }

    protected override Expression VisitMemberInit(MemberInitExpression node)
    {
        return Handle(node, base.VisitMemberInit);
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        return Handle(node, base.VisitMethodCall);
    }

    protected override Expression VisitNew(NewExpression node)
    {
        return Handle(node, base.VisitNew);
    }

    protected override Expression VisitNewArray(NewArrayExpression node)
    {
        return Handle(node, base.VisitNewArray);
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return Handle(node, base.VisitParameter);
    }

    protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
    {
        return Handle(node, base.VisitRuntimeVariables);
    }

    protected override Expression VisitSwitch(SwitchExpression node)
    {
        return Handle(node, base.VisitSwitch);
    }

    protected override Expression VisitTypeBinary(TypeBinaryExpression node)
    {
        return Handle(node, base.VisitTypeBinary);
    }

    protected override Expression VisitTry(TryExpression node)
    {
        return Handle(node, base.VisitTry);
    }

    protected override Expression VisitUnary(UnaryExpression node)
    {
        return Handle(node, base.VisitUnary);
    }

    protected virtual Expression Handle<TExpression>(TExpression expression, Func<TExpression, Expression> @default) where TExpression : Expression?
    {
        var expressionType = typeof(TExpression);
        if (!_handlers.TryGetValue(expressionType, out var handlers))
        {
            return @default(expression);
        }

        if (handlers == null)
        {
            return @default(expression);
        }

        var handler = handlers.SingleOrDefault(x => expression != null && x.CanHandle(expression));
        if (handler == null)
        {
            return @default(expression);
        }

        if (expression != null)
        {
            handler.Handle(expression, Context);
            return expression;
        }

        return @default(expression);
    }
}