namespace Blater.Results;

public partial class BlaterResult<TValue>
{
    public static implicit operator BlaterResult<TValue>(TValue value)
    {
        return new BlaterResult<TValue>(value);
    }
    
    public static implicit operator BlaterResult<TValue>(BlaterError error)
    {
        return new BlaterResult<TValue>(error);
    }
    
    public static implicit operator BlaterResult<TValue>(List<BlaterError> errors)
    {
        return new BlaterResult<TValue>(errors);
    }
    
    public static implicit operator BlaterResult<TValue>(BlaterError[] errors)
    {
        return new BlaterResult<TValue>(errors.ToList());
    }
}