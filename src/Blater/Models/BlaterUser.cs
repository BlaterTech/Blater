namespace Blater.Models;

public class BlaterUser : BaseDataModel
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public bool Verified { get; set; }
}