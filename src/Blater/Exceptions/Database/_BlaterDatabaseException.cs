using Blater.Results;

namespace Blater.Exceptions.Database;

public class BlaterDatabaseException : BlaterException
{
    public BlaterDatabaseException(string message) : base(message)
    {
    }

    public BlaterDatabaseException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public BlaterDatabaseException()
    {
    }
    
    public BlaterDatabaseException(IEnumerable<BlaterError> errors) : base(string.Join(", ", errors))
    {
    }
}