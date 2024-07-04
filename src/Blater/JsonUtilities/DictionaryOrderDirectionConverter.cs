using System.Text.Json;
using System.Text.Json.Serialization;
using Blater.Enumerations;

namespace Blater.JsonUtilities;

public class DictionaryOrderDirectionConverter : JsonConverter<List<IDictionary<string, OrderDirection>>>
{
    public override List<IDictionary<string, OrderDirection>>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonDocument = JsonDocument.ParseValue(ref reader);

        var result = new List<IDictionary<string, OrderDirection>>();

        foreach (var item in jsonDocument.RootElement.EnumerateArray())
        {
            var dict = new Dictionary<string, OrderDirection>();

            foreach (var property in item.EnumerateObject())
            {
                var key = property.Name;
                var value = property.Value.GetString(); // assuming value is string

                if (OrderDirectionExtensions.TryParse(value, out var orderDirection, true, true))
                {
                    dict.Add(key, orderDirection);
                }
                else
                {
                    // Handle parsing failure as needed
                    throw new JsonException($"Unable to parse \"{value}\" as {typeof(OrderDirection)}.");
                }
            }

            result.Add(dict);
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, List<IDictionary<string, OrderDirection>> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var dict in value)
        {
            writer.WriteStartObject();

            foreach (var kvp in dict)
            {
                writer.WritePropertyName(kvp.Key);
                writer.WriteStringValue(kvp.Value.ToStringFast()); // write as string
            }

            writer.WriteEndObject();
        }

        writer.WriteEndArray();
    }
}