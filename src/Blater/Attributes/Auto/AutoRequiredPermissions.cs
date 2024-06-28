using System.Diagnostics.CodeAnalysis;

namespace Blater.Attributes.Auto;

[AttributeUsage(AttributeTargets.All)]
[SuppressMessage("Naming", "CA1710:Os identificadores devem ter o sufixo correto")]
public sealed class AutoRequiredPermissions(List<string> permissions) : Attribute
{
    public List<string> Permissions { get; internal set; } = permissions;
}