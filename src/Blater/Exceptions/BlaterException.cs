using Blater.Results;

namespace Blater.Exceptions;

public class BlaterException : Exception
{
    public BlaterException(string message) : base(message)
    {
    }

    public BlaterException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public BlaterException()
    {
    }

    public BlaterException(List<BlaterError> errors) : base(string.Join(", ", errors.Select(e => e.Message)))
    {
    }
}