namespace Blater.Resullts;

public struct BlaterError : IEquatable<BlaterError>
{
    public BlaterError(string message)
    {
        Message = message;
        Exception = null;
        ErrorType = null;
        AdditionalData = null;
    }
    
    public string Message { get; set; }
    
    public Exception? Exception { get; set; }
    
    public string? ErrorType { get; set; }
    
    public object? AdditionalData { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is BlaterError error)
        {
            return Equals(error);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Message, Exception, ErrorType);
    }

    public static bool operator ==(BlaterError left, BlaterError right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(BlaterError left, BlaterError right)
    {
        return !(left == right);
    }

    public bool Equals(BlaterError other)
    {
        return Message == other.Message && Equals(Exception, other.Exception) && ErrorType == other.ErrorType;
    }
    
    #region Default Errors
    

    
    #endregion
}