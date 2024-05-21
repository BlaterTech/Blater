namespace Blater.Models;

public class BaseDataModel : BaseId
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public string FullTypeName { get; internal set; } = default!;
}