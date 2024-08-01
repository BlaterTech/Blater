using Blater.Enumerations;

namespace Blater.Models.Database;

public class BlaterQuery
{
    /// <summary>
    ///
    /// if empty, returns all
    /// </summary>
    public List<string> Properties { get; set; } = [];

    public required string Container { get; set; }

    public OrderDirection OrderDirection { get; set; }
    
    public required List<BlaterQueryCondition> Conditions { get; set; }
}

public class BlaterQueryCondition
{
    public required string Property { get; set; }
    public required List<string> Values { get; set; }
    public BlaterQueryConditionOperator Operator { get; set; }
}

public enum BlaterQueryConditionOperator
{
    Equal,
    NotEqual,
    GreaterThan,
    GreaterThanOrEqual,
    LessThan,
    LessThanOrEqual,
    Contains,
    StartsWith,
    EndsWith,
    Regex
}