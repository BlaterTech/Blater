// ReSharper disable InconsistentNaming

using System.Text.Json.Serialization;
using Blater.Attributes;

namespace Blater.Enumerations;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlaterProjects
{
    None = 0,
    
    [ShortName("bl")]
    Blater = 1
}