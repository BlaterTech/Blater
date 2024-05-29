namespace Blater.Resullts;

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
        Success = false;
    }

    public BlaterResult(List<BlaterError> errors)
    {
        Errors = errors;
        Success = false;
    }

    public TValue? Value { get; set; }
}