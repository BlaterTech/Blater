using System.ComponentModel;
using NetEscapades.EnumGenerators;

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