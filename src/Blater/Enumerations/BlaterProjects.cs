// ReSharper disable InconsistentNaming

using Blater.Attributes;

using System.Text.Json.Serialization;

namespace Blater.Enumerations;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlaterProjects
{
    None = 0,

    [ShortName("bl")]
    Blater = 1
}