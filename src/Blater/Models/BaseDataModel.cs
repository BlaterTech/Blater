using System.Text.Json.Serialization;
using Blater.Utilities;

namespace Blater.Models;

public class BaseDataModel
{
    public BaseDataModel()
    {
        var type = GetType();
        FullTypeName =  type.FullName?.ToLower().Replace(".", "_", StringComparison.OrdinalIgnoreCase) ?? type.Name;
    }
    
    [JsonPropertyName("_id")]
    public string Id => $"{Partition ?? FullTypeName}:{Guid}";
    
    internal Guid Guid { get; set; } = SequentialGuidGenerator.NewGuid();
    
    public string? Partition { get; set; }
    
    [JsonPropertyName("_rev")]
    public string? Revision { get; internal set; }
    
    internal string FullTypeName { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}