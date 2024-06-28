using System.Diagnostics.CodeAnalysis;

namespace Blater.Attributes.Auto;

[AttributeUsage(AttributeTargets.All)]
[SuppressMessage("Naming", "CA1710:Os identificadores devem ter o sufixo correto")]
public sealed class AutoRequiredRoles(params string[] roleNames) : Attribute
{
    public string[] RoleNames { get; } = roleNames;
}