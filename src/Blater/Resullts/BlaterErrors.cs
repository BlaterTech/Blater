using System.Net;

namespace Blater.Resullts;

public static class BlaterErrors
{
    public static readonly BlaterError GenericInternalError = new("Internal error");
    public static BlaterError InternalError(string error) => new("Internal error: "                                                  + error);
    
    public static BlaterError InternalError(string error, HttpStatusCode statusCode)
    {
        var message = $"""
                      "Status: {statusCode}
                      Internal error: {error}
                      """;
        
        return new BlaterError(message);
    }
    
    public static readonly BlaterError Success = new("Success");
    public static readonly BlaterError NotFound = new("Not found");
    public static readonly BlaterError BadRequest = new("Bad Request");
    
    public static readonly BlaterError DatabaseError = new("Database error");
    public static readonly BlaterError QueryError = new("Failed to generate query");
    public static readonly BlaterError TenantNotFound = new("Tenant not found");
    
    public static BlaterError HttpRequestError(string error = "Failed to make http request")
    {
        return new BlaterError(error);
    }
    
    public static BlaterError JsonSerializationError(string json)
    {
        return new BlaterError($"Failed to serialize json: {json}");
    }
}