using System.Diagnostics.CodeAnalysis;

namespace Blater.Attributes.Auto;

[AttributeUsage(AttributeTargets.All)]
[SuppressMessage("Naming", "CA1710:Os identificadores devem ter o sufixo correto")]
public sealed class AutoRequiredPermissions(params string[] permissions) : Attribute
{
    public string[] Permissions { get; } = permissions;
}