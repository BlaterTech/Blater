namespace Blater.Results;

public class BlaterError
{
    public BlaterError(string message)
    {
        Message = message;
    }
    
    public string Message { get; set; }
}