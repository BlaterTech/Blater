namespace Blater.Models;

public class BlaterUser : BaseId
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; }= string.Empty;

    public string PhoneNumber { get; set; }= string.Empty;

    public bool Verified { get; set; }
}