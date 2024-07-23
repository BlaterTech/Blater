using System;
using System.Text.Json.Serialization;

namespace Blater.Models;

[JsonConverter(typeof(BlaterIdConverter))]
public class BlaterId(string partition, Guid guidValue, string? revision = null, BlaterRevisionInfos? revisions = null)
    : IEquatable<BlaterId>
{
    public Guid GuidValue { get; } = guidValue;

    public string Partition { get; } = partition;

    /// <summary>
    /// Current revision of the document, only available if the document was updated and if requested.
    /// </summary>
    public string? Revision { get; } = revision;

    /// <summary>
    /// Older revisions of the document, only available if the document was updated and if requested.
    /// </summary>
    [JsonPropertyName("_revs_info")]
    public BlaterRevisionInfos? Revisions { get; } = revisions;

    public static BlaterId New(string partition)
    {
        return new BlaterId(partition, SequentialGuidGenerator.NewGuid());
    }

    public static BlaterId Empty { get; set; } = new(string.Empty, Guid.Empty);

    public bool Equals(BlaterId? other)
    {
        if (GuidValue == Guid.Empty || other?.GuidValue == Guid.Empty)
        {
            return false;
        }

        if (string.IsNullOrEmpty(Partition) || string.IsNullOrEmpty(other?.Partition))
        {
            return false;
        }

        if (Revision == null || other.Revision == null)
        {
            return GuidValue.Equals(other.GuidValue) && Partition.Equals(other.Partition, StringComparison.OrdinalIgnoreCase);
        }

        if (string.IsNullOrEmpty(Revision) || string.IsNullOrEmpty(other.Revision))
        {
            return GuidValue.Equals(other.GuidValue) && Partition.Equals(other.Partition, StringComparison.OrdinalIgnoreCase);
        }

        return GuidValue.Equals(other.GuidValue) && Partition.Equals(other.Partition, StringComparison.OrdinalIgnoreCase) &&
               Revision.Equals(other.Revision, StringComparison.OrdinalIgnoreCase);
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

    #region Operators

    public static bool operator ==(BlaterId? left, BlaterId? right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        return left?.Equals(right) ?? false;
    }

    public static bool operator !=(BlaterId? left, BlaterId? right)
    {
        return !(left == right);
    }

    public static bool operator ==(BlaterId? left, Guid right)
    {
        return left?.GuidValue == right;
    }

    public static bool operator !=(BlaterId? left, Guid right)
    {
        return left?.GuidValue != right;
    }

    public static implicit operator string(BlaterId blaterId)
    {
        return blaterId.ToString();
    }

    public static implicit operator BlaterId(string value)
    {
        var parts = value.Split(':');

        if (parts.Length != 2)
        {
            return Empty;
        }

        return new BlaterId(parts[0], Guid.Parse(parts[1]));
    }

    public static implicit operator Guid(BlaterId blaterId)
    {
        return blaterId.GuidValue;
    }

    public static implicit operator BlaterRevisionDictionary(BlaterId blaterId)
    {
        if (blaterId.Revisions == null)
        {
            return new BlaterRevisionDictionary();
        }

        if (blaterId.Revision == null)
        {
            return new BlaterRevisionDictionary();
        }

        return new BlaterRevisionDictionary
        {
            { blaterId, [blaterId.Revision] }
        };
    }

    public BlaterRevisionDictionary ToRevisionDictionary()
    {
        return this;
    }

    #endregion
}