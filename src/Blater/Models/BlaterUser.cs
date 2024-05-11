namespace Blater.Models;

public class BlaterUser : BaseId
{
    public required string Name { get; set; }
    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public bool Verified { get; set; }
}