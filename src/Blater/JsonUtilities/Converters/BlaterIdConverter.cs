using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blater.Models;

namespace Blater.JsonUtilities.Converters
{
    public class BlaterIdConverter : JsonConverter<BlaterId>
    {
        public override BlaterId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? guidValue = null;
            string? partition = null;
            string? revision = null;
            
            var readerCopy = reader;
            
            while (readerCopy.Read())
            {
                if (readerCopy.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = readerCopy.GetString();
                    readerCopy.Read();
                    switch (propertyName)
                    {
                        case "partition":
                            partition = readerCopy.GetString();
                            break;
                        case "guidValue":
                            guidValue = readerCopy.GetString();
                            break;
                        case "rev":
                            revision = readerCopy.GetString();
                            break;
                    }
                }
            }
            
            return new BlaterId(partition!, Guid.Parse(guidValue!), revision);
        }
        
        public override void Write(Utf8JsonWriter writer, BlaterId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Partition}:{value.GuidValue.ToString()}");
            writer.WriteString("partition", value.Partition);
            writer.WriteString("guidValue", value.GuidValue.ToString());
            if (value.Revision != null)
            {
                writer.WriteString("rev", value.Revision);
            }
        }
    }
}