using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blater.JsonUtilities
{
    public class BlaterIdToStringConverter : JsonConverter<BlaterId>
    {
        public override BlaterId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var propertyValue = reader.GetString();
            
            if (propertyValue == null)
            {
                throw new JsonException("Property value is null");
            }
            
            var parts = propertyValue.Split(':');
            
            return new BlaterId(parts[0], Guid.Parse(parts[1]));
        }
        
        public override void Write(Utf8JsonWriter writer, BlaterId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Partition}:{value.GuidValue.ToString()}");
        }
    }
}