using System.Text.Json.Serialization;
using Blater.Enumerations;

namespace Blater.Models;

public readonly struct BlaterRevisionInfo : IEquatable<BlaterRevisionInfo>
{
    [JsonPropertyName("rev")]
    public string Revision { get; init; }

    [JsonPropertyName("status")]
    public BlaterRevisionStatus Status { get; init; }

    public BlaterRevisionInfo(string revision, BlaterRevisionStatus status)
    {
        Revision = revision;
        Status = status;
    }

    public override bool Equals(object? obj)
    {
        return obj is BlaterRevisionInfo info && Equals(info);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Revision, Status);
    }

    public static bool operator ==(BlaterRevisionInfo left, BlaterRevisionInfo right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(BlaterRevisionInfo left, BlaterRevisionInfo right)
    {
        return !(left == right);
    }

    public bool Equals(BlaterRevisionInfo other)
    {
        return Revision == other.Revision && Status == other.Status;
    }
}