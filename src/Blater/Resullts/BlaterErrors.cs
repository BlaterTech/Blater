namespace Blater.Resullts;

public static class BlaterErrors
{
    public static BlaterError HttpRequestError(string message)
    {
        var error = new BlaterError
        {
            Message = message,
            ErrorType = "HttpRequestError"
        };
        return error;
    }
    
    public static BlaterError JsonError(string errorWhileDeserializingResponse, Exception? exception = null)
    {
        var error = new BlaterError
        {
            Message = errorWhileDeserializingResponse,
            Exception = exception,
            ErrorType = "JsonError"
        };
        return error;
    }
    
    public static BlaterError SerializationError<T>(Exception? exception = null)
    {
        var objectName = typeof(T).Name;
        var error = new BlaterError
        {
            Message = "Failed to serialize the object " + objectName,
            Exception = exception,
            ErrorType = "SerializationError"
        };
        return error;
    }
    
    public static BlaterError SerializationError(string objectName, Exception? exception = null)
    {
        var error = new BlaterError
        {
            Message = "Failed to serialize the object " + objectName,
            Exception = exception,
            ErrorType = "SerializationError"
        };
        return error;
    }
    
    public static BlaterError NotFound()
    {
        return new BlaterError
        {
            Message = "The requested resource was not found",
            ErrorType = "NotFound"
        };
    }
    
    public static BlaterError NotFound(string message)
    {
        var error = new BlaterError
        {
            Message = message,
            ErrorType = "NotFound"
        };
        return error;
    }
    
    public static BlaterError QueryError()
    {
        return new BlaterError
        {
            Message = "Failed to convert the expression to a query",
            ErrorType = "QueryError"
        };
    }
    
    public static BlaterError InternalError()
    {
        return new BlaterError
        {
            Message = "An internal error occurred",
            ErrorType = "InternalError"
        };
    }
}