namespace Blater.Models.User;

public class BlaterRole : BaseDataModel
{
    public required string Name { get; set; }
    public List<string> Permissions { get; set; } = [];
}