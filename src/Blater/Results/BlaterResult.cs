using System.Collections.Generic;
using System.Linq;

namespace Blater.Results;

public partial class BlaterResult
{
    public BlaterResult()
    {
        Errors = [];
    }

    public BlaterResult(BlaterError error)
    {
        Errors = [error];
    }

    public BlaterResult(IEnumerable<BlaterError> errors)
    {
        Errors = errors.ToList();
    }

    public bool Success { get; set; }

    public List<string> Messages { get; set; } = [];

    public bool Failure => !Success;

    public bool HasErrors => Errors.Count > 0;

    public List<BlaterError> Errors { get; set; }
}