using System.Text.Json.Serialization;

namespace Blater.Models;

public class BlaterRevisions
{
    [JsonPropertyName("start")]
    public int LatestRevision { get; init; }
    
    [JsonPropertyName("ids")]
    public List<string> Ids { get; init; } = default!;
}