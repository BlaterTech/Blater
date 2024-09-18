namespace Blater.Results;

public class BlaterError(string message, List<string>? errors = null)
{
    public BlaterError(string message, string error) : this(message, [error])
    {
    }

    public string Message { get; } = message;
    public List<string> Errors { get; } = errors ?? [];
}