using Blater.Enumerations;

using System.Text.Json.Serialization;

namespace Blater.Query.Models;

public class BlaterQuery
{
    /// <summary>
    /// JSON object, or <see cref="BlaterQuery"/>, describing criteria used to select documents. More information
    /// provided in the section on selector syntax.
    /// </summary>
    public IDictionary<string, object>? Selector { get; set; }

    /// <summary>
    /// Maximum number of results returned. Default is 25. Optional
    /// </summary>
    public long? Limit { get; set; } = 25;

    /// <summary>
    /// Skip the first n results, where n is the value specified. Optional
    /// </summary>
    public long? Skip { get; set; }

    /// <summary>
    /// the sorts to apply to this query, note an index is required to use a sort.
    /// </summary>
    public List<IDictionary<string, OrderDirection>>? Sort { get; set; }

    public List<string>? Fields { get; set; }

    /// <summary>
    /// [design document] [index name]
    /// </summary>
    [JsonPropertyName("use_index")]
    public object? Index { get; set; }

    public bool? Conflicts { get; set; }

    /// <summary>
    /// Read N amount of datbase nodes to make sure the document is the same on all nodes
    /// </summary>
    public int? ReadQorum { get; set; }

    public string? Bookmark { get; set; }
    
    [JsonPropertyName("execution_stats")]
    public bool ExecutionStats { get; set; }
    #if DEBUG
        = true;
    #endif
}