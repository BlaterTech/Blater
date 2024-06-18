
using System.Linq.Expressions;
using System.Reflection;

namespace Blater.Query.Helpers;

/// <summary>
/// Type related helper methods
/// </summary>
public static class TypeHelper
{
    public static Type? FindIEnumerable(Type? seqType)
    {
        if (seqType == null || seqType == typeof(string))
        {
            return null;
        }
        
        var elementType = GetElementType(seqType);
        
        if (elementType != null && seqType.IsArray)
        {
            return typeof(IEnumerable<>).MakeGenericType(elementType);
        }
        
        var info = seqType.GetTypeInfo();
        if (info.IsGenericType)
        {
            foreach (var arg in info.GenericTypeParameters)
            {
                var ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                if (ienum.GetTypeInfo().IsAssignableFrom(info))
                {
                    return ienum;
                }
            }
        }
        var implementedInterfaces = info.ImplementedInterfaces.ToList();
        if (implementedInterfaces.Count != 0)
        {
            foreach (var implementedInterface in implementedInterfaces)
            {
                var enumerable = FindIEnumerable(implementedInterface);
                if (enumerable != null)
                {
                    return enumerable;
                }
            }
        }
        if (info.BaseType != null && info.BaseType != typeof(object))
        {
            return FindIEnumerable(info.BaseType);
        }
        return null;
    }
    
    public static Type GetSequenceType(Type elementType)
    {
        return typeof(IEnumerable<>).MakeGenericType(elementType);
    }
    
    public static Type? GetElementType(Type? seqType)
    {
        var implementedEnumerable = FindIEnumerable(seqType);
        if (implementedEnumerable == null)
        {
            return seqType;
        }
        
        return implementedEnumerable.GetTypeInfo().GenericTypeParameters[0];
    }
    
    public static bool IsNullableType(Type? type)
    {
        return type                            != null && type.GetTypeInfo().IsGenericType &&
               type.GetGenericTypeDefinition() == typeof(Nullable<>);
    }
    
    public static bool IsNullAssignable(Type? type)
    {
        return type != null && (!type.GetTypeInfo().IsValueType || IsNullableType(type));
    }
    
    public static Type? GetNonNullableType(Type? type)
    {
        if (IsNullableType(type) && type != null)
        {
            return type.GetTypeInfo().GenericTypeParameters[0];
        }
        return type;
    }
    
    public static Type? GetNullAssignableType(Type? type)
    {
        if (type == null)
        {
            return null;
        }
        
        if (!IsNullAssignable(type))
        {
            return typeof(Nullable<>).MakeGenericType(type);
        }
        return type;
    }
    
    public static ConstantExpression GetNullConstant(Type? type)
    {
        return Expression.Constant(null, GetNullAssignableType(type) ?? typeof(object));
    }
    
    public static Type? GetMemberType(MemberInfo mi)
    {
        var fi = mi as FieldInfo;
        if (fi != null)
        {
            return fi.FieldType;
        }
        
        var pi = mi as PropertyInfo;
        if (pi != null)
        {
            return pi.PropertyType;
        }
        
        var ei = mi as EventInfo;
        if (ei != null)
        {
            return ei.EventHandlerType;
        }
        
        var meth = mi as MethodInfo; // property getters really
        if (meth != null)
        {
            return meth.ReturnType;
        }
        
        return null;
    }
    
    public static object? GetDefault(Type? type)
    {
        if (type == null)
        {
            return null;
        }
        
        var isNullable = !type.GetTypeInfo().IsValueType || IsNullableType(type);
        if (!isNullable)
        {
            return Activator.CreateInstance(type);
        }
        
        return null;
    }
    
    public static bool IsReadOnly(MemberInfo member)
    {
        switch (member.MemberType)
        {
            case MemberTypes.Field:
                return (((FieldInfo)member).Attributes & FieldAttributes.InitOnly) != 0;
            case MemberTypes.Property:
                var propertyInfo = (PropertyInfo)member;
                return !propertyInfo.CanWrite || propertyInfo.GetSetMethod() == null;
            default:
                return true;
        }
    }
    
    public static bool IsInteger(Type? type)
    {
        //TODO does this work?
        GetNonNullableType(type);
        switch (Type.GetTypeCode(type))
        {
            case TypeCode.SByte:
            case TypeCode.Int16:
            case TypeCode.Int32:
            case TypeCode.Int64:
            case TypeCode.Byte:
            case TypeCode.UInt16:
            case TypeCode.UInt32:
            case TypeCode.UInt64:
                return true;
            default:
                return false;
        }
    }
}