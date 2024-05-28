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
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            string? guidValue = null;
            string? partition = null;
            string? revision = null;

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.EndObject:
                        return new BlaterId
                        {
                            GuidValue = Guid.Parse(guidValue!),
                            Partition = partition!,
                            Revision = revision
                        };
                    case JsonTokenType.PropertyName:
                    {
                        var propertyName = reader.GetString();
                        reader.Read();
                        switch (propertyName)
                        {
                            case "GuidValue":
                                guidValue = reader.GetString();
                                break;
                            case "Partition":
                                partition = reader.GetString();
                                break;
                            case "rev":
                            case "_rev":
                                revision = reader.GetString();
                                break;
                        }
                        
                        break;
                    }
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, BlaterId value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("guidValue", value.GuidValue.ToString());
            writer.WriteString("partition", value.Partition);
            if (value.Revision != null)
            {
                writer.WriteString("_rev", value.Revision);
                writer.WriteString("rev", value.Revision);
            }
            writer.WriteEndObject();
        }
    }
}