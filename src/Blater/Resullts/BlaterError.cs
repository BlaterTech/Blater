namespace Blater.Resullts;

public class BlaterError(string message)
{
    public string Message { get; set; } = message;
}