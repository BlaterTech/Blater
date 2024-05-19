namespace Blater.BlaterResults;

public static class BlaterResultErrors
{
    public static readonly BlaterResult Success = new(BlaterErrors.Success);
    public static readonly BlaterResult NotFound = new(BlaterErrors.NotFound);
    public static readonly BlaterResult SerializationError = new(BlaterErrors.SerializationError);
}