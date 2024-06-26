namespace Blater.Models.User;

public class BlaterUserToken
{
    public string UserId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<string> Roles { get; set; } = [];
    public List<string> Permissions { get; set; } = [];
}