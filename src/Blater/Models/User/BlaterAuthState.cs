using System.Diagnostics.CodeAnalysis;

namespace Blater.Models.User;

[SuppressMessage("Design", "CA1056:As propriedades do tipo URI não devem ser cadeias de caracteres")]
public class BlaterAuthState
{
    public string UserId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string AvatarUrl { get; set; } = null!;
    
    public bool LockoutEnabled { get; set; }
    
    public bool LoggedIn { get; set; }
    
    public List<string> RoleNames { get; set; } = [];
    
    public List<string> Permissions { get; set; } = [];
    
    public string JwtToken { get; set; } = null!;
}