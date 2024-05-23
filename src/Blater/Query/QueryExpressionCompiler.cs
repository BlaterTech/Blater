using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Text;
using Blater.Query.Extensions;
using Humanizer;

namespace Blater.Query
{
    [SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
    public class QueryExpressionCompiler(StringBuilder stringBuilder) : ExpressionVisitor
    {
        public StringBuilder StringBuilder { get; } = stringBuilder;
        
        public string CompileToBlaterQuery(Expression expression, List<string> selectProperties, List<string> sortProperties)
        {
            StringBuilder.Append("{ \"selector\": {");
            Visit(expression);
            StringBuilder.Append('}');
            
            if (selectProperties.Count != 0)
            {
                StringBuilder.Append(", \"fields\": [");
                for (var i = 0; i < selectProperties.Count; i++)
                {
                    if (i > 0)
                    {
                        StringBuilder.Append(", ");
                    }
                    StringBuilder.Append($"\"{selectProperties[i].Camelize()}\"");
                }
                StringBuilder.Append(']');
            }
            
            if (sortProperties.Count != 0)
            {
                StringBuilder.Append(", \"sort\": [");
                for (var i = 0; i < sortProperties.Count; i++)
                {
                    if (i > 0)
                    {
                        StringBuilder.Append(", ");
                    }
                    StringBuilder.Append($"{{ \"{sortProperties[i].Camelize()}\": \"asc\" }}"); // Assuming "asc" sort order
                }
                StringBuilder.Append(']');
            }
            
            StringBuilder.Append('}');
            return StringBuilder.ToString();
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            //StringBuilder.Append($"\"{node.Member.Name}\"");
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            //if (node.Type == typeof(string))
            //{
            //    StringBuilder.Append($"\"{node.Value}\"");
            //}
            //else
            //{
            //    StringBuilder.Append(node.Value);
            //}
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            return node;
            /*switch (node.Method.Name)
            {
                case nameof(string.Contains):
                    Visit(node.Object);
                    StringBuilder.Append(": { \"$regex\": ");
                    Visit(node.Arguments[0]);
                    StringBuilder.Append(" }");
                    return node;
                case nameof(Enumerable.Any) when node.Arguments.Count == 2:
                    Visit(node.Arguments[0]);
                    StringBuilder.Append(": { \"$elemMatch\": ");
                    Visit(node.Arguments[1]);
                    StringBuilder.Append(" }");
                    return node;
                case nameof(Enumerable.All) when node.Arguments.Count == 2:
                    Visit(node.Arguments[0]);
                    StringBuilder.Append(": { \"$allMatch\": ");
                    Visit(node.Arguments[1]);
                    StringBuilder.Append(" }");
                    return node;
                case nameof(QueryExtensions.Regex) when node.Arguments.Count == 2:
                    Visit(node.Arguments[0]);
                    StringBuilder.Append(": { \"$regex\": ");
                    Visit(node.Arguments[1]);
                    StringBuilder.Append(" }");
                    return node;
                case nameof(QueryExtensions.In) when node.Arguments.Count == 2:
                    Visit(node.Arguments[0]);
                    StringBuilder.Append(": { \"$elemMatch\": ");
                    Visit(node.Arguments[1]);
                    StringBuilder.Append(" }");
                    return node;
                default:
                    throw new NotSupportedException($"The method '{node.Method.Name}' is not supported");
            }*/
        }
    }
}
