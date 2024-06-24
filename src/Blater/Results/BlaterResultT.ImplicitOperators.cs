namespace Blater.Results;

public partial class BlaterResult<TValue>
{
    public static implicit operator BlaterResult<TValue>(TValue value)
    {
        return new BlaterResult<TValue>(value)
        {
            Success = true
        };
    }
    
    public static implicit operator BlaterResult<TValue>((TValue value, string message) tuple)
    {
        return new BlaterResult<TValue>(tuple.value)
        {
            Success = true,
            Messages = [tuple.message]
        };
    }
    
    public static implicit operator BlaterResult<TValue>(BlaterError error)
    {
        return new BlaterResult<TValue>(error)
        {
            Success = false
        };
    }
    
    public static implicit operator BlaterResult<TValue>(List<BlaterError> errors)
    {
        return new BlaterResult<TValue>(errors)
        {
            Success = false
        };
    }
    
    public static implicit operator BlaterResult<TValue>(BlaterError[] errors)
    {
        return new BlaterResult<TValue>(errors.ToList())
        {
            Success = false
        };
    }
}