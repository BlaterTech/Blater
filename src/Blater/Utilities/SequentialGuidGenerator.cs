namespace Blater.Utilities;

/// <summary>
///     Generates a new sequential GUID.
/// </summary>
public static class SequentialGuidGenerator
{
    /// <summary>
    /// Generate a new sequential GUID.
    /// </summary>
    /// <returns></returns>
    public static Guid NewGuid()
    {
        var timeStamp = DateTime.UtcNow.Ticks;

        //Generate random 8 bytes
        var randomBytes = new byte[8];
        Random.Shared.NextBytes(randomBytes);

        return new Guid(
            (int)(timeStamp   >> 32),
            (short)(timeStamp >> 16),
            (short)timeStamp, randomBytes);
    }
}