using NetEscapades.EnumGenerators;

using System.Text.Json.Serialization;

namespace Blater.Enumerations;

[EnumExtensions]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LanguageTranslation
{
    English,
    Portugues
}