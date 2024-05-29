using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

// ReSharper disable UnusedMember.Global

namespace Blater.Models;

[SuppressMessage("Design", "CA1044:Properties should not be write only")]
public class BaseDataModel
{
    protected BaseDataModel()
    {
        var type = GetType();
        var typeName = type.FullName?.SanitizeString() ?? type.Name;
        //Creates a new BlaterId with the sanitized type name.
        Id = new BlaterId(typeName);
    }
    
    [JsonPropertyName("_id")]
    public BlaterId Id { get; set; }
    
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