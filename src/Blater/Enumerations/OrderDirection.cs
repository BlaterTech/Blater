using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NetEscapades.EnumGenerators;


namespace Blater.Enumerations;

[EnumExtensions]
public enum OrderDirection
{
    /// <summary>
    /// Ascending order
    /// </summary>
    Ascending,

    /// <summary>
    /// Descending order
    /// </summary>
    Descending
}