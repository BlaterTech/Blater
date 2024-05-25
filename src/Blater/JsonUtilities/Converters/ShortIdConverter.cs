using System.Text.Json;
using System.Text.Json.Serialization;
using Blater.Utilities;

namespace Blater.JsonUtilities.Converters;

public class ShortIdConverter : JsonConverter<ShortGuid>
{
    public override ShortGuid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException();
        }
        
        var stringValue = reader.GetString();
        
        if (stringValue == null)
        {
            throw new JsonException("Value is null");
        }
        
        return new ShortGuid(stringValue);
    }
    
    public override void Write(Utf8JsonWriter writer, ShortGuid value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}