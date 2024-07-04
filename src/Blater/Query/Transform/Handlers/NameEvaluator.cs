using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers;

/// <summary>
/// this will extract the name an expression.
/// </summary>
internal class NameEvaluator : ExpressionVisitor
{
    private readonly VisitorContext? _context;

    private readonly DynamicDictionary? _right;

    //private bool _started;
    public DynamicDictionary? Query;


    public NameEvaluator(VisitorContext? context, DynamicDictionary? right)
    {
        _context = context;
        _right = right;
    }

    public override Expression? Visit(Expression? exp)
    {
        return exp == null ? null : base.Visit(exp);
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        var isDictionary = typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(node.Method.DeclaringType);

        //only support dictionary index by name
        if (!isDictionary || (node.Method.Name != "get_Item" && node.Method.Name != "ContainsKey"))
        {
            return node;
        }

        if (node.Arguments.Count > 1)
        {
            throw new Exception("sorry get_Item (dictionary indexer) is supported, and there seems to be more than one");
        }

        if (node.Arguments.FirstOrDefault() is not ConstantExpression arg)
        {
            throw new Exception("sorry get_Item (dictionary indexer) is supported, and there seems to be no args");
        }

        //Append($"[\"{arg.Value}\"]", false);
        Append($"{arg.Value}");

        var result = base.VisitMethodCall(node);
        return result;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        var name = node.Member.Name.ToCamelCase();

        //Check if it has JsonPropertyNameAttribute
        var jsonPropertyNameAttribute = node.Member.GetCustomAttribute<JsonPropertyNameAttribute>();

        var actualName = jsonPropertyNameAttribute?.Name ?? name;

        Append(actualName);

        var result = base.VisitMember(node);
        return result;
    }

    private void Append(string name)
    {
        if (Query == null)
        {
            Query = new DynamicDictionary
            {
                { name, _right ?? throw new Exception("right is null") }
            };
        }
        else
        {
            Query = new DynamicDictionary
            {
                { name, Query }
            };
        }
    }
}