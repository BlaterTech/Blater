namespace Blater.BlaterResults;

public class BlaterResult
{
    public BlaterResult() => Errors = [];

    public BlaterResult(BlaterError error) => Errors = [error];

    public BlaterResult(IEnumerable<BlaterError> errors) => Errors = errors.ToList();

    public bool Success { get; set; }

    public bool Failure => !Success;

    public bool HasErrors => Errors.Count > 0;

    public List<BlaterError> Errors { get; set; }
}