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
}