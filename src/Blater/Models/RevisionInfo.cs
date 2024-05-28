using System.Text.Json.Serialization;

namespace Blater.Models;

public class RevisionInfo
{

    [JsonPropertyName("rev")]
    public string Rev { get; set; } = null!;
    

    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;
}