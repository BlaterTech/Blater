using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Blater.Query.Extensions;
using Humanizer;

namespace Blater.Query
{
    [SuppressMessage("Globalization", "CA1305:Specify IFormatProvider")]
    public class QueryExpressionCompiler(StringBuilder stringBuilder) : ExpressionVisitor
    {
        public StringBuilder StringBuilder { get; } = stringBuilder;
        
        public string CompileToBlaterQuery(Expression expression, List<string> selectProperties, List<(string field, string direction)> sortProperties)
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
                    
                    StringBuilder.Append($"{{ \"{sortProperties[i].field.Camelize()}\": \"{sortProperties[i].direction}\" }}"); // Assuming "asc" sort order
                }
                
                StringBuilder.Append(']');
            }
            
            StringBuilder.Append('}');
            return StringBuilder.ToString();
        }
        
        private Dictionary<MemberInfo, List<string>> _members = new();
        
        protected override Expression VisitBinary(BinaryExpression node)
        {
            // Logical operators handling
            /*if (node.NodeType is ExpressionType.AndAlso or ExpressionType.And)
            {
                StringBuilder.Append("{ \"$and\": [");
                Visit(node.Left);
                StringBuilder.Append(", ");
                Visit(node.Right);
                StringBuilder.Append("] }");
                return node;
            }
            if (node.NodeType is ExpressionType.OrElse or ExpressionType.Or)
            {
                StringBuilder.Append("{ \"$or\": [");
                Visit(node.Left);
                StringBuilder.Append(", ");
                Visit(node.Right);
                StringBuilder.Append("] }");
                return node;
            }*/
            
            // Comparison operators handling
            Visit(node.Left);
            
            /*switch (node.NodeType)
            {
                case ExpressionType.Equal:
                    StringBuilder.Append(": { \"$eq\": ");
                    break;
                case ExpressionType.NotEqual:
                    StringBuilder.Append(": { \"$ne\": ");
                    break;
                case ExpressionType.GreaterThan:
                    StringBuilder.Append(": { \"$gt\": ");
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    StringBuilder.Append(": { \"$gte\": ");
                    break;
                case ExpressionType.LessThan:
                    StringBuilder.Append(": { \"$lt\": ");
                    break;
                case ExpressionType.LessThanOrEqual:
                    StringBuilder.Append(": { \"$lte\": ");
                    break;
                default:
                    //throw new NotSupportedException($"The binary operator '{node.NodeType}' is not supported");
                    Console.WriteLine($"The binary operator '{node.NodeType}' is not supported");
                    break;
            }*/
            
            Visit(node.Right);
            return node;
        }
        
        protected override Expression VisitMember(MemberExpression node)
        {
            _members.TryAdd(node.Member, new List<string>());
            StringBuilder.Append($"\"{node.Member.Name.Camelize()}\":");
            return node;
        }
        
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type == typeof(string))
            {
                StringBuilder.Append($"\"{node.Value}\"");
            }
            else
            {
                StringBuilder.Append(node.Value);
            }
            
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
                    StringBuilder.Append("},");
                    return node;
                case nameof(Enumerable.Any) when node.Arguments.Count == 2:
                    Visit(node.Arguments[0]);
                    StringBuilder.Append(": { \"$elemMatch\": ");
                    Visit(node.Arguments[1]);
                    StringBuilder.Append("},");
                    return node;
                case nameof(Enumerable.All) when node.Arguments.Count == 2:
                    Visit(node.Arguments[0]);
                    StringBuilder.Append(": { \"$allMatch\": ");
                    Visit(node.Arguments[1]);
                    StringBuilder.Append("},");
                    return node;
                case nameof(QueryExtensions.Regex) when node.Arguments.Count == 2:
                    Visit(node.Arguments[0]);
                    StringBuilder.Append(": { \"$regex\": ");
                    Visit(node.Arguments[1]);
                    StringBuilder.Append("},");
                    return node;
                case nameof(QueryExtensions.In) when node.Arguments.Count == 2:
                    Visit(node.Arguments[0]);
                    StringBuilder.Append(": { \"$elemMatch\": ");
                    Visit(node.Arguments[1]);
                    StringBuilder.Append("},");
                    return node;
                default:
                    throw new NotSupportedException($"The method '{node.Method.Name}' is not supported");
            }*/
        }
    }
}