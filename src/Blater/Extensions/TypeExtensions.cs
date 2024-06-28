using System.Collections;
using System.Reflection;

namespace Blater.Extensions;

internal static class TypeExtensions
{
    /*public static string GetName(this Type t, CouchOptions options)
    {
        object[] jsonObjectAttributes = t.GetCustomAttributes(typeof(JsonObjectAttribute), true);
        JsonObjectAttribute? jsonObject = jsonObjectAttributes.Length > 0
            ? jsonObjectAttributes[0] as JsonObjectAttribute
            : null;
    
        if (jsonObject != null)
        {
            return jsonObject.Id;
        }
    
        var typeName = t.Name;
        if (options.PluralizeEntities)
        {
            typeName = typeName.Pluralize();
        }
        return options.DocumentsCaseType.Convert(typeName);
    }*/
    
    public static Type GetSequenceType(this Type type)
    {
        var sequenceType = TryGetSequenceType(type);
        if (sequenceType == null)
        {
            throw new ArgumentException("Sequence type not found.", nameof(type));
        }
        
        return sequenceType;
    }
    
    public static Type? TryGetSequenceType(this Type type)
        => type.TryGetElementType(typeof(IEnumerable<>))
        ?? type.TryGetElementType(typeof(IAsyncEnumerable<>));
    
    public static Type? TryGetElementType(this Type type, Type interfaceOrBaseType)
    {
        if (type.IsGenericTypeDefinition)
        {
            return null;
        }
        
        var types = GetGenericTypeImplementations(type, interfaceOrBaseType);
        
        Type? singleImplementation = null;
        foreach (var implementation in types)
        {
            if (singleImplementation == null)
            {
                singleImplementation = implementation;
            }
            else
            {
                singleImplementation = null;
                break;
            }
        }
        
        return singleImplementation?.GenericTypeArguments.FirstOrDefault();
    }
    
    public static IEnumerable<Type> GetGenericTypeImplementations(this Type type, Type interfaceOrBaseType)
    {
        var typeInfo = type.GetTypeInfo();
        
        if (typeInfo.IsGenericTypeDefinition)
        {
            yield break;
        }
        
        var baseTypes = interfaceOrBaseType.GetTypeInfo().IsInterface
            ? typeInfo.ImplementedInterfaces
            : type.GetBaseTypes();
        
        foreach (var baseType in baseTypes)
        {
            if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == interfaceOrBaseType)
            {
                yield return baseType;
            }
        }
        
        if (type.IsGenericType && type.GetGenericTypeDefinition() == interfaceOrBaseType)
        {
            yield return type;
        }
    }
    
    public static object? GetDefaultValue(this Type type)
    {
        ArgumentNullException.ThrowIfNull(type);
        
        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }
        
        if (type == typeof(string))
        {
            return string.Empty;
        }
        
        if (type == typeof(int))
        {
            return 0;
        }
        
        if (type == typeof(double))
        {
            return 0.0;
        }
        
        if (type == typeof(float))
        {
            return 0.0f;
        }
        
        if (type == typeof(decimal))
        {
            return 0.0m;
        }
        
        if (type == typeof(Guid))
        {
            return Guid.Empty;
        }
        
        return default;
    }
    
    public static bool IsEnumerable(this Type type)
    {
        return type.IsArray || typeof(IEnumerable).IsAssignableFrom(type);
    }
    
    private static IEnumerable<Type> GetBaseTypes(this Type? type)
    {
        type = type?.BaseType;
        
        while (type != null)
        {
            yield return type;
            
            type = type.BaseType;
        }
    }
}