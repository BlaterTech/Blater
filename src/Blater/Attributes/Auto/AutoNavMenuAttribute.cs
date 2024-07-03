namespace Blater.Attributes.Auto;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AutoNavMenuAttribute : Attribute
{
    public AutoNavMenuAttribute()
    {
        Order = 1;
    }
    
    public AutoNavMenuAttribute(string icon)
    {
        Order = 1;
        Icon = icon;
    }
    
    public AutoNavMenuAttribute(int order, string? icon = null)
    {
        Order = order;
        Icon = icon;
    }
    
    public int Order { get; internal set; }
    
    public string? Icon { get; internal set; }
    
    public string? NavMenuParentName { get; set; }
}