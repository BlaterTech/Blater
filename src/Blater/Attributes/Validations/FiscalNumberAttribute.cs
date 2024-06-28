using System.ComponentModel.DataAnnotations;

namespace Blater.Attributes.Validations;

/// <summary>
///     International Fiscal Number
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public sealed class FiscalNumberAttribute : ValidationAttribute
{
}