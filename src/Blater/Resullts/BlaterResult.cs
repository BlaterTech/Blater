using OneOf;

namespace Blater.Resullts;


[GenerateOneOf]
public partial class BlaterResult<TValue> : OneOfBase<TValue, BlaterError>
{
    public bool HasError(out BlaterError error, out TValue value)
    {
        return TryPickT1(out error, out value);
    }
    
    public bool IsError => IsT1;
}