using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Blater.Models;

[SuppressMessage("Design", "CA1044:Properties should not be write only")]
public class Revisions
{
    [JsonIgnore]
    public int Start { get; private set; }


    [JsonPropertyName("start")]
    public int StartOther
    {
        set => Start = value;
    }


    [JsonPropertyName("ids")]
    public List<string> Ids { get; set; } = [];
}