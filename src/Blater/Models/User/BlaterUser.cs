namespace Blater.Models.User;

public sealed class BlaterUser : BaseDataModel
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool EmailConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public DateTimeOffset LastLoginDate { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public bool Verified { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public List<BlaterLoginInfo> Logins { get; set; } = [];
    
    /// <summary>
    /// CreateDatabase, CreateUser
    /// </summary>
    public List<string> Permissions { get; set; } = [];
    
    /// <summary>
    /// Admin, Support, Owner
    /// </summary>
    public List<string> RoleNames { get; set; } = [];

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }
}