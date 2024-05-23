using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NetEscapades.EnumGenerators;

namespace Blater.Enumerations;

[EnumExtensions]
public enum OrderDirection
{
    /// <summary>
    /// Ascending order
    /// </summary>
    [Display(Name = "asc")]
    Ascending,
    
    /// <summary>
    /// Descending order
    /// </summary>
    [Display(Name = "desc")]
    Descending
}