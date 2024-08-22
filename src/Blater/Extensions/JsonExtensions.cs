using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blater.Extensions;

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
            new JsonStringEnumConverter(),
            new Cysharp.Serialization.Json.UlidJsonConverter()
        },
        #if DEBUG
        WriteIndented = true,
        #endif
    };

    public static string? ToJson(this object? str, JsonSerializerOptions? options = null)
    {
        return str == null ? null : JsonSerializer.Serialize(str, options ?? DefaultJsonSerializerOptions);
    }
    
    public static Memory<byte> ToJsonBytes(this object? str, JsonSerializerOptions? options = null)
    {
        return str == null ? Memory<byte>.Empty : JsonSerializer.SerializeToUtf8Bytes(str, options ?? DefaultJsonSerializerOptions);
    }

    public static JsonDocument? ToJsonDocument(this string? str)
    {
        return str == null ? null : JsonSerializer.Deserialize<JsonDocument>(str, DefaultJsonSerializerOptions);
    }
    
    public static JsonElement? ToJsonElement(this string? str)
    {
        
        return str?.ToJsonDocument()?.RootElement;
    }

    public static T? FromJson<T>(this string? str, JsonSerializerOptions? options = null)
    {
        return str == null ? default : JsonSerializer.Deserialize<T>(str, options ?? DefaultJsonSerializerOptions);
    }
    
    public static async Task<T?> FromJson<T>(this Stream stream, JsonSerializerOptions? options = null)
    {
        stream.Position = 0;
        return await JsonSerializer.DeserializeAsync<T>(stream, options ?? DefaultJsonSerializerOptions);
    }
    
    public static T? FromJson<T>(this Memory<byte> bytes, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(bytes.Span, options ?? DefaultJsonSerializerOptions);
    }
    
    public static T? FromJson<T>(this ReadOnlyMemory<byte> bytes, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(bytes.Span, options ?? DefaultJsonSerializerOptions);
    }
    
    public static T? FromJson<T>(this in Span<byte> bytes, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(bytes, options ?? DefaultJsonSerializerOptions);
    }
    
    public static T? FromJson<T>(this in ReadOnlySpan<byte> bytes, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(bytes, options ?? DefaultJsonSerializerOptions);
    }
    
    public static T? FromJson<T>(this byte[] bytes, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(bytes, options ?? DefaultJsonSerializerOptions);
    }
    
    public static bool TryParseJson<T>(this string? str, out T? result)
    {
        result = default;
        try
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            result = str.FromJson<T>();
            return result != null;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}