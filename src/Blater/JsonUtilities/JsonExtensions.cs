using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Blater.JsonUtilities;

public static class JsonExtensions
{
    public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        Converters =
        {
            new BlaterIdConverter(),
            new JsonStringEnumConverter()
        },
#if DEBUG
        WriteIndented = true,
#endif
    };

    public static string? ToJson(this object? str, JsonSerializerOptions? options = null)
    {
        return str == null ? null : JsonSerializer.Serialize(str, options ?? DefaultJsonSerializerOptions);
    }
    
    public static JsonObject? ToJsonObject(this string? str)
    {
        return str == null ? null : FromJson<JsonObject>(str);
    }

    public static T? FromJson<T>(this string? str, JsonSerializerOptions? options = null)
    {
        return str == null ? default : JsonSerializer.Deserialize<T>(str, options ?? DefaultJsonSerializerOptions);
    }
    
    public static async Task<T?> FromJson<T>(this Stream stream)
    {
        stream.Position = 0;
        return await JsonSerializer.DeserializeAsync<T>(stream, DefaultJsonSerializerOptions);
    }
}