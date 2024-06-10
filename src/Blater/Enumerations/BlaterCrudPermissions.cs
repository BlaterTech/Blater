using System.ComponentModel.DataAnnotations;
using NetEscapades.EnumGenerators;

namespace Blater.Enumerations;

[Flags]
[EnumExtensions]
public enum BlaterCrudPermissions
{
    Create = 1,
    Read = 2,
    Update = 4,
    Delete = 8,
    All = Create | Read | Update | Delete
}