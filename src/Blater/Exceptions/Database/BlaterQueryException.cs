using System;

namespace Blater.Exceptions.Database;

public class BlaterQueryException : BlaterDatabaseException
{
    public BlaterQueryException(string message) : base(message)
    {
    }

    public BlaterQueryException()
    {
    }

    public BlaterQueryException(string message, Exception innerException) : base(message, innerException)
    {
    }
}