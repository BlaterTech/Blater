namespace Blater.Models.Database;

public class BlaterRevision
{
    public int Iteration { get; set; }
    public required string Hash { get; set; }
}