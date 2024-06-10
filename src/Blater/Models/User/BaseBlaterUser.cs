namespace Blater.Models.User;

public abstract class BaseBlaterUser : BaseDataModel
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
}