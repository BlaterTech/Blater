namespace Blater.BlaterResults;

public static class BlaterResultResponses
{
    public static readonly BlaterResult Success = new(BlaterErrors.Success);
    public static readonly BlaterResult Failed = new(BlaterErrors.InternalError);
    public static readonly BlaterResult NotFound = new(BlaterErrors.NotFound);
    public static readonly BlaterResult SerializationError = new(BlaterErrors.SerializationError);
}