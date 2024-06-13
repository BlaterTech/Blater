namespace Blater.Results;

public static class BlaterResults
{
    public static readonly BlaterResult Success = new(BlaterErrors.Success);
    public static readonly BlaterResult Failed = new(BlaterErrors.GenericInternalError);
    public static readonly BlaterResult NotFound = new(BlaterErrors.NotFound);
    public static readonly BlaterResult SerializationError = BlaterErrors.JsonSerializationError("Failed to serialize object");
}