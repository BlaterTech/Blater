using System.Linq.Expressions;

namespace Blater.Query.Transform.Handlers.BinaryHandlers;

/// <summary>
/// this will extract the member and value form a Binary expression.
/// </summary>
internal class MemberNameEvaluator : ExpressionVisitor
{
    public ConstantExpression? Value { get; private set; }
    public Expression? Property { get; private set; }
    
    public override Expression? Visit(Expression? exp)
    {
        return exp == null ? null : base.Visit(exp);
    }
    
    protected override Expression VisitBinary(BinaryExpression node)
    {
        if (node.Left is ConstantExpression left)
        {
            Value = left;
            Property = node.Right;
        }
        
        if (node.Right is ConstantExpression right)
        {
            Value = right;
            Property = node.Left;
        }
        
        return node;
    }
}