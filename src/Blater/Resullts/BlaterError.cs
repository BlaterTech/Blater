namespace Blater.Resullts;

public class BlaterError(string message, List<string>? errors = null)
{
    public string Message { get; set; } = message;
    public List<string> Errors { get; set; } = errors ?? [];
}