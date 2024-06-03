namespace Blater.Resullts;

public partial class BlaterResult
{
    /*public static implicit operator BlaterResult<TValue>(TValue value)
    {
        return new BlaterResult(value);
    }*/
    
    public static implicit operator BlaterResult(BlaterError error)
    {
        return new BlaterResult(error);
    }
    public static implicit operator BlaterResult(List<BlaterError> errors)
    {
        return new BlaterResult(errors);
    }
    
    public static implicit operator BlaterResult(BlaterError[] errors)
    {
        return new BlaterResult(errors.ToList());
    }
}