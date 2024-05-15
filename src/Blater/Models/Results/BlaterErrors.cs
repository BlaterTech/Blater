namespace Blater.Models.Results;

public static class BlaterErrors
{
    public static readonly BlaterError InternalError = new("Internal error");
    public static readonly BlaterError Success = new("Success");
    public static readonly BlaterError NotFound = new("Not found");
    public static readonly BlaterError SerializationError = new("Serialization error");
    public static readonly BlaterError DatabaseError = new("Database error");
    public static readonly BlaterError TenantNotFound = new("Tenant not found");
}