namespace Blater.BlaterResults;

public class BlaterError
{
    public BlaterError(string message)
    {
        Message = message;
    }
    
    public string Message { get; set; }
}