using System.ComponentModel;
using System.Text.Json.Serialization;
using NetEscapades.EnumGenerators;

namespace Blater.Enumerations.Chat;

[EnumExtensions]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageStatus
{
    [Description("sent")]
    Sent,

    [Description("read")]
    Read,

    [Description("typing")]
    Typing
}