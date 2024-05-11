namespace Blater.Models.Results;

public class BlaterError
{
    public BlaterError(string message)
    {
        Message = message;
    }
    
    public string Message { get; set; }
}