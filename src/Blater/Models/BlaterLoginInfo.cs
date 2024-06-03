namespace Blater.Models;

public class BlaterLoginInfo
{
    public string LoginProvider { get; set; } = null!;
    public string? ProviderDisplayName { get; set; }
    public string ProviderKey { get; set; } = null!;
}