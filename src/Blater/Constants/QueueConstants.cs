namespace Blater.Constants;

public static class QueueConstantsss
{
    public const int MaxMessageSize = 256 * 1024;
    public const int MaxMessageCount = 10;
    public const int RetriesBeforeDlq = 5;
    public static readonly TimeSpan DefaultVisibilityTimeout = new(0, 5, 0);
}