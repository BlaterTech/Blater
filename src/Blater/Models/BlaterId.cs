using System.Text.Json.Serialization;

namespace Blater.Models;

public class BlaterId : IEquatable<BlaterId>
{
    internal BlaterId(string partition, Guid guidValue)
    {
        Partition = partition;
        GuidValue = guidValue;
    }

    internal BlaterId(string partition, Guid guidValue, string? revision)
    {
        Partition = partition;
        GuidValue = guidValue;
        Revision = revision;
    }

    internal BlaterId(string partition, Guid guidValue, string? revision, BlaterRevisions? revisions)
    {
        Partition = partition;
        GuidValue = guidValue;
        Revision = revision;
        Revisions = revisions;
    }

    public Guid GuidValue { get; }

    public string Partition { get; }

    public string? Revision { get; }

    /// <summary>
    /// Older revisions of the document, only available if the document was updated and if requested.
    /// </summary>
    [JsonPropertyName("_revisions")]
    public BlaterRevisions? Revisions { get; }

    public static bool operator ==(BlaterId left, BlaterId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(BlaterId left, BlaterId right)
    {
        return !(left == right);
    }

    public static bool operator ==(BlaterId left, Guid right)
    {
        return left.GuidValue == right;
    }

    public static bool operator !=(BlaterId left, Guid right)
    {
        return left.GuidValue != right;
    }

    public static bool operator ==(BlaterId left, string right)
    {
        return left.Partition.Equals(right, StringComparison.OrdinalIgnoreCase);
    }

    public static bool operator !=(BlaterId left, string right)
    {
        return !left.Partition.Equals(right, StringComparison.OrdinalIgnoreCase);
    }

    public bool Equals(BlaterId? other)
    {
        return GuidValue != Guid.Empty && (other?.GuidValue) != Guid.Empty
&& !string.IsNullOrEmpty(Partition) && !string.IsNullOrEmpty(other?.Partition)
&& (Revision == null || other.Revision == null
            ? GuidValue.Equals(other.GuidValue) && Partition.Equals(other.Partition, StringComparison.OrdinalIgnoreCase)
            : string.IsNullOrEmpty(Revision) || string.IsNullOrEmpty(other.Revision)
            ? GuidValue.Equals(other.GuidValue) && Partition.Equals(other.Partition, StringComparison.OrdinalIgnoreCase)
            : GuidValue.Equals(other.GuidValue) && Partition.Equals(other.Partition, StringComparison.OrdinalIgnoreCase) &&
               Revision.Equals(other.Revision, StringComparison.OrdinalIgnoreCase));
    }

    public static implicit operator string(BlaterId blaterId)
    {
        return blaterId.ToString();
    }

    public override bool Equals(object? obj)
    {
        return obj is BlaterId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GuidValue, Partition, Revision);
    }

    public override string ToString()
    {
        return $"{Partition}:{GuidValue}";
    }

    
}