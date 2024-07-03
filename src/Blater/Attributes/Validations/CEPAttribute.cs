using System.ComponentModel.DataAnnotations;

namespace Blater.Attributes.Validations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class CEPAttribute() : ValidationAttribute("O campo {0} não é um CNPJ válido.")
{
    public override bool IsValid(object? value)
    {
        if (value is string stringValue)
        {
            return stringValue.ValidateCpf();
        }
        
        return false;
    }
}