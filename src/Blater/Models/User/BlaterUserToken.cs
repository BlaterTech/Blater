namespace Blater.Models.User;

public class BlaterUserToken
{
    public string UserId { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string AvatarImage { get; set; } = null!;
    
    public string Jwt { get; set; } = null!;
    
    public bool LockoutEnabled { get; set; }
    
    public List<string> Roles { get; set; } = [];
    
    public List<string> Permissions { get; set; } = [];
}