using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EnumFastToStringGenerated;

namespace Blater.Enumerations;

[EnumGenerator]
public enum OrderDirection
{
    /// <summary>
    /// Ascending order
    /// </summary>
    [Display(Name = "asc")]
    [JsonPropertyName("asc")]
    Ascending,
    
    /// <summary>
    /// Descending order
    /// </summary>
    [Display(Name = "desc")]
    [JsonPropertyName("desc")]
    Descending
}