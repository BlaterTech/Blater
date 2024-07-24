using System.Text.Json.Serialization;
using Blater.Models.Database;

namespace Blater.Models.Bases;

public class BaseDataModel
{
    public Ulid Id { get; set; } = default!;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    ///     Deletion flag.
    ///     Available if document was removed.
    /// </summary>
    [JsonIgnore]
    public bool Deleted { get; private set; }

    public BlaterRevision? Revision { get; set; }

    //public bool Enabled { get; set; }
}