using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

// ReSharper disable UnusedMember.Global

namespace Blater.Models;

[SuppressMessage("Design", "CA1044:Properties should not be write only")]
public class BaseDataModel
{
    [JsonPropertyName("_id")]
    public BlaterId Id { get; set; } = default!;
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    
    /// <summary>
    ///     Deletion flag.
    ///     Available if document was removed.
    /// </summary>
    
    [JsonIgnore]
    public bool Deleted { get; private set; }
}