using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace Blater.Extensions;

public static class PropertiesExtensions
{
    public static bool IsPropertyNullOrDefault<T>(this T value)
    {
        var props = value!.GetType().GetProperties();

        return props.All(prop =>
        {
            var propValue = prop.GetValue(value);

            if (propValue == null)
            {
                return true;
            }

            if (prop.PropertyType == typeof(bool))
            {
                return true;
            }

            if (prop.PropertyType == typeof(string))
            {
                return string.IsNullOrWhiteSpace((string)propValue);
            }

            if (prop.PropertyType == typeof(int))
            {
                return (int)propValue == 0;
            }

            if (prop.PropertyType == typeof(decimal))
            {
                return (decimal)propValue == 0;
            }

            if (prop.PropertyType == typeof(Guid))
            {
                return (Guid)propValue == Guid.Empty;
            }

            if (prop.PropertyType == typeof(DateTimeOffset))
            {
                return (DateTimeOffset)propValue == DateTimeOffset.MinValue;
            }

            if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var list = propValue as IList;
                return list is { Count: 0 };
            }

            if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                var dictionary = propValue as IDictionary;
                return dictionary is { Count: 0 };
            }

            return false;
        });
    }
    
    public static string GetPropertyName<TProperty>(this Expression<Func<TProperty>> propertyExpression)
    {
        return propertyExpression.Body switch
        {
            MemberExpression memberExpression => memberExpression.Member.Name,
            UnaryExpression { Operand: MemberExpression operand } => operand.Member
                                                                            .Name,
            _ => throw new ArgumentException("Invalid expression")
        };
    }
    
    public static PropertyInfo GetPropertyInfo<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression)
    {
        if (expression.Body is MemberExpression memberExpression)
        {
            // Retorna o nome da propriedade
            return (PropertyInfo)memberExpression.Member;
        }
        throw new ArgumentException("Invalid expression");
    }
}