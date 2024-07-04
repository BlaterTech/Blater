// Copyright (c) Microsoft Corporation.  All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (MS-PL)

using System.Linq.Expressions;
using System.Reflection;
using Blater.Query.Extensions;
using Blater.Query.Helpers;
using FastExpressionCompiler;

namespace Blater.Query.Visitors;

/// <summary>
/// Rewrites an expression tree so that locally sortable sub-expressions are evaluated and converted into ConstantExpression nodes.
/// </summary>
public static class PartialEvaluator
{
    /// <summary>
    /// Performs evaluation and replacement of independent sub-trees
    /// </summary>
    /// <param name="expression">The root of the expression tree.</param>
    /// <param name="fnCanBeEvaluated">A function that decides whether a given expression node can be part of the local function.</param>
    /// <returns>A new tree with subtrees evaluated and replaced.</returns>
    public static Expression? Eval(Expression expression, Func<Expression, bool> fnCanBeEvaluated)
    {
        return SubtreeEvaluator.Eval(Nominator.Nominate(fnCanBeEvaluated, expression), expression);
    }

    /// <summary>
    /// Performs evaluation and replacement of independent subtrees
    /// </summary>
    /// <param name="expression">The root of the expression tree.</param>
    /// <returns>A new tree with subtrees evaluated and replaced.</returns>
    public static Expression? Eval(Expression expression)
    {
        return Eval(expression, CanBeEvaluatedLocally);
    }

    private static bool CanBeEvaluatedLocally(Expression expression)
    {
        return expression.NodeType != ExpressionType.Parameter;
    }

    /// <summary>
    /// Evaluates and replaces subtrees when first candidate is reached (top-down)
    /// </summary>
    private class SubtreeEvaluator : ExpressionVisitor
    {
        private readonly HashSet<Expression> _candidates;

        private SubtreeEvaluator(HashSet<Expression> candidates)
        {
            _candidates = candidates;
        }

        internal static Expression? Eval(HashSet<Expression> candidates, Expression exp)
        {
            return new SubtreeEvaluator(candidates).Visit(exp);
        }

        public override Expression? Visit(Expression? exp)
        {
            if (exp == null)
            {
                return null;
            }

            if (_candidates.Contains(exp))
            {
                return Evaluate(exp);
            }

            return base.Visit(exp);
        }

        private static Expression Evaluate(Expression e)
        {
            var type = e.Type;

            switch (e.NodeType)
            {
                case ExpressionType.Convert:
                {
                    // check for unnecessary convert & strip them
                    var u = (UnaryExpression)e;
                    if (TypeHelper.GetNonNullableType(u.Operand.Type) == TypeHelper.GetNonNullableType(type))
                    {
                        e = ((UnaryExpression)e).Operand;
                    }

                    break;
                }
                // in case we actually threw out a nullable conversion above, simulate it here
                case ExpressionType.Constant when e.Type == type:
                    return e;
                case ExpressionType.Constant when TypeHelper.GetNonNullableType(e.Type) == TypeHelper.GetNonNullableType(type):
                    return Expression.Constant(((ConstantExpression)e).Value, type);
            }

            if (e is MemberExpression { Expression: ConstantExpression ce } me)
                // member accesses off of constants are common, and yet since these partial evals
                // are never re-used, using reflection to access the member is faster than compiling  
                // and invoking a lambda
            {
                var value = ce.Value;
                me.Member.GetValue(value);

                //If ce type is BlaterId
                /*if (actualValue is BlaterId blaterId)
                {
                    return Expression.Constant(blaterId.ToString(), typeof(string));
                }*/

                return Expression.Constant(me.Member.GetValue(value), type);
            }

            if (type.GetTypeInfo().IsValueType)
            {
                e = Expression.Convert(e, typeof(object));
            }

            var lambda = Expression.Lambda<Func<object>>(e);

            var fn = lambda.CompileFast();

            return Expression.Constant(fn(), type);
        }
    }
}

/// <summary>
/// Performs bottom-up analysis to determine which nodes can possibly
/// be part of an evaluated subtree.
/// </summary>
internal class Nominator : ExpressionVisitor
{
    private readonly Func<Expression, bool> _fnCanBeEvaluated;
    private readonly HashSet<Expression> _candidates;
    private bool _cannotBeEvaluated;

    private Nominator(Func<Expression, bool> fnCanBeEvaluated)
    {
        _candidates = new HashSet<Expression>();
        _fnCanBeEvaluated = fnCanBeEvaluated;
    }

    internal static HashSet<Expression> Nominate(Func<Expression, bool> fnCanBeEvaluated, Expression expression)
    {
        var nominator = new Nominator(fnCanBeEvaluated);
        nominator.Visit(expression);
        return nominator._candidates;
    }

    protected override Expression VisitConstant(ConstantExpression c)
    {
        return base.VisitConstant(c);
    }

    public override Expression? Visit(Expression? expression)
    {
        if (expression == null)
        {
            return expression;
        }

        var saveCannotBeEvaluated = _cannotBeEvaluated;
        _cannotBeEvaluated = false;
        base.Visit(expression);

        if (!_cannotBeEvaluated)
        {
            if (_fnCanBeEvaluated(expression))
            {
                _candidates.Add(expression);
            }
            else
            {
                _cannotBeEvaluated = true;
            }
        }

        _cannotBeEvaluated |= saveCannotBeEvaluated;
        return expression;
    }
}