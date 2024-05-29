using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blater.Database.Converters;

public class JsonEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var enumValue = reader.GetString();
        foreach (var field in typeof(T).GetFields())
        {
            var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (descriptionAttribute != null && descriptionAttribute.Description == enumValue)
            {
                return (T)(field.GetValue(null) ?? throw new InvalidOperationException());
            }
        }
        throw new JsonException($"Unable to convert \"{enumValue}\" to Enum \"{typeof(T)}\".");
    }
    
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var field = typeof(T).GetField(value.ToString());
        if (field == null)
        {
            return;
        }
        
        var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
        writer.WriteStringValue(descriptionAttribute != null ? descriptionAttribute.Description : value.ToString());
    }
}