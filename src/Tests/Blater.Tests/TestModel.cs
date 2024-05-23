using System.Runtime.Serialization;
using Blater.Attributes;
using Blater.Models;
using Blater.Relation;

namespace Blater.Tests;

public class TestModel : BaseDataModel
{
    public int Year { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public List<string> StringList { get; set; } = new List<string>();
}