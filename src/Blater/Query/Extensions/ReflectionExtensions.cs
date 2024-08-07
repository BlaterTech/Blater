using System.Reflection;

namespace Blater.Query.Extensions;

public static class ReflectionExtensions
{
    public static object? GetValue(this MemberInfo? member, object? instance)
    {
        if (member == null)
        {
            return null;
        }

        if (instance == null)
        {
            return null;
        }

        switch (member.MemberType)
        {
            case MemberTypes.Property:
                return ((PropertyInfo)member).GetValue(instance, null);
            case MemberTypes.Field:
                return ((FieldInfo)member).GetValue(instance);
            default:
                return null;
        }
    }

    public static void SetValue(this MemberInfo member, object instance, object value)
    {
        switch (member.MemberType)
        {
            case MemberTypes.Property:
                var pi = (PropertyInfo)member;
                pi.SetValue(instance, value, null);
                break;
            case MemberTypes.Field:
                var fi = (FieldInfo)member;
                fi.SetValue(instance, value);
                break;
            default:
                throw new InvalidOperationException();
        }
    }
}