using NetEscapades.EnumGenerators;

using System.ComponentModel;

namespace Blater.Enumerations;

[EnumExtensions]
public enum BlaterRevisionStatus
{
    [Description("available")]
    Available,

    [Description("deleted")]
    Deleted,

    [Description("missing")]
    Missing
}