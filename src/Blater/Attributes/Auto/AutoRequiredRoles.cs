using System.Diagnostics.CodeAnalysis;

namespace Blater.Attributes.Auto;

[AttributeUsage(AttributeTargets.All)]
[SuppressMessage("Naming", "CA1710:Os identificadores devem ter o sufixo correto")]
public sealed class AutoRequiredRoles(List<string> rolenames) : Attribute
{
    public List<string> RoleNames { get; internal set; } = rolenames;
}