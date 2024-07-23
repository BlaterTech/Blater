using System.Collections.Generic;

namespace Blater.Results;

public partial class BlaterResult<TValue> : BlaterResult
{
    public BlaterResult()
    {
        Success = false;
        Errors = [];
    }

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

    public bool HandleErrors(out List<BlaterError> errors, out TValue value)
    {
        if (HasErrors)
        {
            errors = Errors;
            value = Value!;
            return true;
        }

        errors = [];
        value = Value!;
        return false;
    }
}