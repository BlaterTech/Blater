using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blater.JsonUtilities
{
    public class BlaterIdConverter : JsonConverter<BlaterId>
    {
        public override BlaterId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? guidValue = null;
            string? partition = null;
            string? revision = null;
            BlaterRevisionInfos? revisions = null;
            
            var readerCopy = reader;
            
            while (readerCopy.Read())
            {
                if (readerCopy.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = readerCopy.GetString();
                    readerCopy.Read();
                    switch (propertyName)
                    {
                        case "id":
                            var compostId = readerCopy.GetString();
                            if (compostId != null)
                            {
                                var parts = compostId.Split(':');
                                partition = parts[0];
                                guidValue = parts[1];
                            }
                            break;
                        case "partition":
                            partition = readerCopy.GetString();
                            break;
                        case "guidValue":
                            guidValue = readerCopy.GetString();
                            break;
                        case "rev":
                        case "_rev":
                            revision = readerCopy.GetString();
                            break;
                        case "_revs_info":
                            revisions = JsonSerializer.Deserialize<BlaterRevisionInfos>(ref readerCopy, options);
                            break;
                    }
                }
            }
            
            if (partition == null || guidValue == null)
            {
                throw new JsonException("BlaterId must have a partition and a guidValue, could not find them in the JSON.");
            }
            
            var blaterId = new BlaterId(partition, Guid.Parse(guidValue), revision, revisions);
            return blaterId;
        }
        
        public override void Write(Utf8JsonWriter writer, BlaterId value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Partition}:{value.GuidValue.ToString()}");
            writer.WriteString("partition", value.Partition);
            writer.WriteString("guidValue", value.GuidValue.ToString());
            if (value.Revision != null)
            {
                writer.WriteString("_rev", value.Revision);
            }
        }
    }
}