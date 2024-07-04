using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NetEscapades.EnumGenerators;


namespace Blater.Enumerations;

[EnumExtensions]
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