using Blater.Utilities;

namespace Blater.Models;

public class BlaterUserInternal : BaseDataModel
{
    public List<BlaterLoginInfo> Logins { get; set; } = [];
    
    public string? UserName { get; set; }
    
    public string? NormalizedUserName { get; set; }
    
    public string? Email { get; set; }
    
    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }
    
    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }
    
    public string? ConcurrencyStamp { get; set; } = SequentialGuidGenerator.NewGuid().ToString();
    
    public string? PhoneNumber { get; set; }
    
    public bool PhoneNumberConfirmed { get; set; }
    
    public bool TwoFactorEnabled { get; set; }
    
    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }
    
    public int AccessFailedCount { get; set; }
    
    public override string ToString()
    {
        return UserName ?? string.Empty;
    }
}