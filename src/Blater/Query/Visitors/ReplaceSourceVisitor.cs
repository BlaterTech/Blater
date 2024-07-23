using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace Blater.Query.Visitors;

public class ReplaceSourceVisitor : ExpressionVisitor
{
    private readonly IEnumerable _newSource;
    private readonly Expression _toReplace;

    private ReplaceSourceVisitor(IEnumerable newSource, Expression toReplace)
    {
        _newSource = newSource;
        _toReplace = toReplace;
    }

    public static Expression Eval(Expression fullExpression, Expression subQueryExpression, IEnumerable newSource)
    {
        var toReplace = ((MethodCallExpression)subQueryExpression).Arguments[0];
        var visitor = new ReplaceSourceVisitor(newSource, toReplace);
        return visitor.Visit(fullExpression);
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        if (node != _toReplace)
        {
            return base.VisitMethodCall(node);
        }

        var queryable = _newSource.AsQueryable();
        var newSourceConstant = Expression.Constant(queryable);
        return newSourceConstant;
    }
}