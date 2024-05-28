using System.Text.Json.Serialization;
using Blater.Utilities;

namespace Blater.Models;

public struct BlaterId : IEquatable<BlaterId>
{
    public BlaterId(string partition)
    {
        Partition = partition;
        GuidValue = SequentialGuidGenerator.NewGuid();
    }
    
    public BlaterId(string partition, Guid guidValue)
    {
        Partition = partition;
        GuidValue = guidValue;
    }
    
    public BlaterId(string partition, Guid guidValue, string? revision)
    {
        Partition = partition;
        GuidValue = guidValue;
        Revision = revision;
    }
    
    public Guid GuidValue { get; set; }
    
    public string Partition { get; set; }
    
    public string? Revision { get; set; }
    
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

    public bool Equals(BlaterId other)
    {
        if (Revision == null || other.Revision == null)
        {
            return GuidValue.Equals(other.GuidValue) && Partition.Equals(other.Partition, StringComparison.OrdinalIgnoreCase);
        }
        
        return GuidValue.Equals(other.GuidValue) && Partition.Equals(other.Partition, StringComparison.OrdinalIgnoreCase) && Revision.Equals(other.Revision, StringComparison.OrdinalIgnoreCase);
    }
    
    public static implicit operator string(BlaterId blaterId)
    {
        return blaterId.ToString();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        
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