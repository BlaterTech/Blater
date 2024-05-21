using System.Linq.Expressions;
using Blater.Query.Extensions;

namespace Blater.Query
{
    internal static class ExpressionExtensions
    {
        public static MemberExpression ToMemberExpression(this Expression selector)
        {
            if (selector is not LambdaExpression { Body: MemberExpression m })
            {
                throw new ArgumentException("The given expression does not select a property.", nameof(selector));
            }

            return m;
        }

        public static string GetPropertyName(this MemberExpression m)
        {
            
            var members = new List<string> { m.Member.GetBlaterPropertyName() };

            var currentExpression = m.Expression;

            if (currentExpression is MemberExpression rootMemberExpression && rootMemberExpression.Type.IsEnumerable())
            {
                throw new NotSupportedException();
            }

            while (currentExpression is MemberExpression cm)
            {
                members.Add(cm.Member.GetBlaterPropertyName());
                currentExpression = cm.Expression;
            }

            members.Reverse();
            var propName = string.Join(".", members.ToArray());

            return propName;
        }

        public static bool ContainsSelector(this Expression expression) =>
            expression is MethodCallExpression { Arguments.Count: 2 } m && m.Arguments[1].IsSelectorExpression();

        private static bool IsSelectorExpression(this Expression selector) =>
            selector is UnaryExpression { Operand: LambdaExpression { Body: MemberExpression } };

        public static Type GetSelectorType(this MethodCallExpression selector) =>
            selector.Arguments[1] is UnaryExpression { Operand: LambdaExpression { Body: MemberExpression m } }
                ? m.Type
                : throw new InvalidOperationException(
                    $"Method {selector.Method.Name} does not select a property.");

        public static Delegate GetSelectorDelegate(this MethodCallExpression selector) =>
            selector.Arguments[1] is UnaryExpression { Operand: LambdaExpression l }
                ? l.Compile()
                : throw new InvalidOperationException(
                    $"Method {selector.Method.Name} does not select a property.");

        public static Expression GetLambdaBody(this MethodCallExpression node)
            => node.GetLambda().Body;

        public static LambdaExpression GetLambda(this MethodCallExpression node)
        {
            return (LambdaExpression)node.Arguments[1].StripQuotes();
        }

        public static Expression WrapInLambda(this Expression body, IReadOnlyCollection<ParameterExpression> lambdaParameters)
        {
            var lambdaExpression = Expression.Lambda(body, lambdaParameters);
            return Expression.Quote(lambdaExpression);
        }

        public static MethodCallExpression WrapInWhereExpression<TSource>(this Expression<Func<TSource, bool>> selector)
        {
            var whereExpression = Expression.Call(typeof(Queryable), nameof(Queryable.Where),
                                                  [typeof(TSource)], Expression.Constant(Array.Empty<TSource>().AsQueryable()), selector);
            return whereExpression;
        }

        private static Expression StripQuotes(this Expression e)
        {
            while (e.NodeType == ExpressionType.Quote)
            {
                e = ((UnaryExpression)e).Operand;
            }
            return e;
        }
    }
}
