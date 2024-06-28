using System.Text.Json.Serialization;
using NetEscapades.EnumGenerators;

namespace Blater.Enumerations;

[EnumExtensions]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LanguageTranslation
{
    English,
    Portugues
}