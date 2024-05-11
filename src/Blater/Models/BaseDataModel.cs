namespace Blater.Models;

public class BaseDataModel : BaseId
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}