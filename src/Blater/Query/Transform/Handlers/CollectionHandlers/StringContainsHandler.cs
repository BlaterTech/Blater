using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using Blater.Query.Models;

namespace Blater.Query.Transform.Handlers.CollectionHandlers;

public class AnyHandler : MethodHandler
{
    public override void Handle(MethodCallExpression expression, VisitorContext? context)
    {
        if (context == null)
        {
            return;
        }
        
        context.Visit(expression.Arguments[1]);
        var matchCriteria = context.GetResult();
        
        var regex = new DynamicDictionary
        {
            { "$elemMatch", matchCriteria }
        };
        var query = CreateQuery(expression.Arguments[0], regex, context);
        
        context.SetResult(query);
    }
    
    public override bool CanHandle(MethodCallExpression expression)
    {
        if (expression.Method.Name != "Any")
        {
            return false;
        }
        
        if (expression.Arguments[0] is not MemberExpression val0 || expression.Arguments[1] is not LambdaExpression)
        {
            return false;
        }
        
        var prop = val0.Member as PropertyInfo;
        return prop != null && typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(prop.PropertyType.GetTypeInfo());
    }
}