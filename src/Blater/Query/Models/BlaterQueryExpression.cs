using System;
using System.Collections;
using System.Linq.Expressions;
using Blater.Query.Visitors;

namespace Blater.Query.Models;

public class BlaterQueryExpression(MethodCallExpression subQueryExpression, Expression fullExpression)
{
    private readonly Expression? _fullExpression = fullExpression;

    public Expression? Expression { get; private set; }

    public void RewriteSource(IEnumerable newSource)
    {
        if (_fullExpression == null)
        {
            throw new Exception("Full expression is null");
        }

        if (Expression == null)
        {
            throw new Exception("Expression is null");
        }

        var temp = ReplaceSourceVisitor.Eval(_fullExpression, subQueryExpression, newSource);
        Expression = temp;
    }
}