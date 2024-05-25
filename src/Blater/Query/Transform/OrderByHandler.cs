using System.Linq.Expressions;

namespace Blater.Query.Transform;

public class OrderByHandler
{
    /// <summary>
    /// gets the full name of the field (hello.world)
    /// </summary>
    /// <param name="memberExpression">the expression to pull this from</param>
    /// <returns></returns>
    public virtual string GetMemberName(MemberExpression memberExpression)
    {
        if (memberExpression.Expression is not MemberExpression prefixExpression)
        {
            return memberExpression.Member.Name;
        }
        
        var prefix = GetMemberName(prefixExpression);
        return string.Join(".", prefix, memberExpression.Member.Name);
    }
}