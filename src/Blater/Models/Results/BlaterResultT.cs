namespace Blater.Models.Results;

public partial class BlaterResult<TValue> : BlaterResult
{
    public BlaterResult(TValue value)
    {
        Success = true;
        Value = value;
        Errors = [];
    }

    public BlaterResult(BlaterError error)
    {
        Errors = [error];
    }

    public BlaterResult(List<BlaterError> errors)
    {
        Errors = errors;
    }

    public TValue? Value { get; set; }
}