using Blater.Models.Database;

namespace Blater.Models.Bases;

public class BaseDataModel
{
    /// <summary>
    /// Can be created either by the SDK or by the Database
    /// </summary>
    public Ulid Id { get; set; } = default!;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// Shadow property for soft delete
    /// </summary>
    public bool Removed { get; private set; }

    /// <summary>
    /// Nullable revision for Blater
    /// </summary>
    public BlaterRevision? Revision { get; set; }
}