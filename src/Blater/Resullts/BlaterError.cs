namespace Blater.Resullts;

public class BlaterError
{
    public BlaterError(string message)
    {
        Message = message;
    }
    
    public string Message { get; set; }
}