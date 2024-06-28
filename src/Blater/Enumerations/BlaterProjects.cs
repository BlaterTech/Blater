// ReSharper disable InconsistentNaming

using System.Text.Json.Serialization;

namespace Blater.Enumerations;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BlaterProjects
{
    None = 0,
}