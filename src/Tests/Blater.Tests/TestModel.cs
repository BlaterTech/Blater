using Blater.Models;

namespace Blater.Tests;

public class TestModel : BaseDataModel
{
    public int Year { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public List<string> StringList { get; set; } = new();
}