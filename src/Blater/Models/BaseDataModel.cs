using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Blater.Utilities;
// ReSharper disable UnusedMember.Global

namespace Blater.Models;

[SuppressMessage("Design", "CA1044:Properties should not be write only")]
[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
public class BaseDataModel
{
    public BaseDataModel()
    {
        var type = GetType();
        FullTypeName =  type.FullName?.SanitizeString() ?? type.Name;
    }
    
    [JsonPropertyName("_id")]
    public string Id => $"{Partition ?? FullTypeName}:{Guid}";
    
    public Guid Guid { get; set; }
    
    public string? Partition { get; set; }
    
    [JsonPropertyName("rev")]
    public string? Revision { get; set; }
    
    internal string FullTypeName { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    
    /// <summary>
    ///     Deletion flag.
    ///     Available if document was removed.
    /// </summary>
    
    [JsonIgnore]
    public bool Deleted { get; private set; }
    
    
    #region TODO
    

    [JsonIgnore]
    public IReadOnlyCollection<string> Conflicts { get; private set; } = default!;


    [JsonPropertyName("_conflicts")]
    public List<string> ConflictsOther
    {
        set => Conflicts = value.AsReadOnly();
    }


    [JsonIgnore]
    public IReadOnlyCollection<string> DeletedConflicts { get; private set; } = default!;


    [JsonPropertyName("_deleted_conflicts")]
    public List<string> DeletedConflictsOther
    {
        set => DeletedConflicts = value.AsReadOnly();
    }


    [JsonIgnore]
    public int LocalSequence { get; private set; }


    [JsonPropertyName("_localSeq")]
    public int LocalSequenceOther
    {
        set => LocalSequence = value;
    }


    [JsonIgnore]
    public IReadOnlyCollection<RevisionInfo> RevisionsInfo { get; private set; } = default!;


    [JsonPropertyName("_revs_info")]
    public List<RevisionInfo> RevisionsInfoOther
    {
        set => RevisionsInfo = value.AsReadOnly();
    }

    /// <summary>
    ///     List of local revision tokens without.
    ///     Available if requested with <see cref="Models.Revisions" /> set to <c>True</c>
    /// </summary>

    [JsonIgnore]
    public Revisions? Revisions { get; private set; }


    [JsonPropertyName("_revisions")]
    public Revisions RevisionsOther
    {
        set => Revisions = value;
    }
    
    #endregion
}