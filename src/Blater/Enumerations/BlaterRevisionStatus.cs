using System.ComponentModel;
using EnumFastToStringGenerated;

namespace Blater.Enumerations;

[EnumGenerator]
public enum BlaterRevisionStatus
{
    [Description("available")]
    Available,
    [Description("deleted")]
    Deleted,
    [Description("missing")]
    Missing
}