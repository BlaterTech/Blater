using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Blater.JsonUtilities.Converters;

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
            new ShortIdConverter(),
            new JsonStringEnumConverter()
        },
        #if DEBUG
        WriteIndented = true,
        #endif
    };
    
    public static string? ToJson(this object? str)
    {
        return str == null ? null : JsonSerializer.Serialize(str, DefaultJsonSerializerOptions);
    }
    
    public static string? ToJson(this object? str, JsonSerializerOptions options)
    {
        return str == null ? null : JsonSerializer.Serialize(str, options);
    }
    
    public static JsonObject? ToJsonObject(this string? str)
    {
        return str == null ? null : FromJson<JsonObject>(str);
    }
    
    public static T? FromJson<T>(this string? str)
    {
        return str == null ? default : JsonSerializer.Deserialize<T>(str, DefaultJsonSerializerOptions);
    }
}