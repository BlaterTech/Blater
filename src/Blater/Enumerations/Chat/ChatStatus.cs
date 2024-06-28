using System.ComponentModel;
using System.Text.Json.Serialization;
using NetEscapades.EnumGenerators;

namespace Blater.Enumerations.Chat;

[EnumExtensions]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ChatStatus
{
    [Description("typing")]
    Typing,
    
    [Description("online")]
    Online,
    
    [Description("away")]
    Away,
    
    [Description("offline")]
    Offline
}