namespace Blater.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class RelationAttribute<TType> : Attribute;