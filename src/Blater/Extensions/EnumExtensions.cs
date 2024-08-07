using System.ComponentModel;
using System.Globalization;

namespace Blater.Extensions;

public static class EnumGenerator
{
    public static string? GetDescription(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name != null)
        {
            var field = type.GetField(name);
            if (field != null)
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                {
                    return attr.Description;
                }
            }
        }

        return null;
    }

    public static string GetEnumErrorCode<T>(this T enumValue) where T : Enum
    {
        var enumName = enumValue.GetType().Name;
        var enumValueCode = Convert
                           .ToInt32(enumValue, CultureInfo.InvariantCulture)
                           .ToString("D4", CultureInfo.InvariantCulture);
        return $"{enumName}{enumValueCode}";
    }
}