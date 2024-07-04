using Blater.Models;
using Blater.Models.Bases;

namespace Blater.Tests;

public class TestModel : BaseDataModel
{
    public int Year { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public List<string> StringList { get; set; } = new();
}