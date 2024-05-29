using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Blater.Models;

[SuppressMessage("Design", "CA1044:Properties should not be write only")]
public class BlaterRevisions
{
    [JsonPropertyName("start")]
    public int Start { get; init; }
    
    [JsonPropertyName("ids")]
    public List<string> Ids { get; init; } = default!;
}