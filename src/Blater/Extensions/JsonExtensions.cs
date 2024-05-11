using System.Text.Json;
using System.Text.Json.Nodes;

namespace Blater.Extensions
{
	public static class JsonExtensions
	{
		public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new()
		{
			PropertyNameCaseInsensitive = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			AllowTrailingCommas = true,
			ReadCommentHandling = JsonCommentHandling.Skip
		};
		
		public static string? ToJson(this object? str)
		{
			return str == null ? null : JsonSerializer.Serialize(str, DefaultJsonSerializerOptions);
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
}
