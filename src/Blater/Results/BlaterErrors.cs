namespace Blater.Results;

public static class BlaterErrors
{
    public static BlaterError Error(string error)
    {
        var message = $"Error: {error}";

        return new BlaterError(message);
    }

    public static BlaterError Error(List<BlaterError> errors)
    {
        var message = errors
           .Aggregate("", (current, error)
                          => current + $"{error.Message}, {string.Join(", ", error.Errors)}");

        return new BlaterError(message);
    }

    public static readonly BlaterError Success = new("Success");
    public static readonly BlaterError NotFound = new("Not found");

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

    public static BlaterError InvalidOperation(string error)
    {
        return new BlaterError(error);
    }
}