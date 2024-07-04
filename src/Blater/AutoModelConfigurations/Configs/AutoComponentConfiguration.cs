using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using Blater.Enumerations.AutoModel;

// ReSharper disable CollectionNeverQueried.Global

namespace Blater.AutoModelConfigurations.Configs;

[SuppressMessage("Design", "CA1051:Não declarar campos de instância visíveis")]
[SuppressMessage("Globalization", "CA1305:Especificar IFormatProvider")]
public class AutoComponentConfiguration
{
    public readonly Dictionary<AutoComponentDisplayType, BaseAutoComponentTypeEnumeration> ComponentTypes = new();

    /// <summary>
    ///     Used for metadata
    /// </summary>
    public readonly Dictionary<string, object> ExtraAttributes = new();

    public readonly Dictionary<AutoComponentDisplayType, AutoGridConfiguration> Grids = new();

    public readonly Dictionary<AutoComponentDisplayType, int> Order = new();

    public readonly Dictionary<AutoComponentDisplayType, AutoFieldSize> Sizes = new();
    public PropertyInfo? Property { get; internal set; }

    public bool SeparateCard { get; set; }

    //Specific configurations

    /// <summary>
    ///     Used to set the field as important and hide the non-important fields
    /// </summary>
    public bool Important { get; set; }

    public bool SeparateComponent { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"PropName:({Property?.Name})");
        sb.AppendLine($"Order:({string.Join(',', Order.Select(x => $"{x.Key}:{x.Value}"))})");
        sb.AppendLine($"Sizes:({string.Join(',', Sizes.Select(x => $"{x.Key}:{x.Value}"))})");
        sb.AppendLine($"AutoComponentTypes:({string.Join(',', ComponentTypes.Select(x => $"{x.Key}:{x.Value.Name}"))})");
        sb.AppendLine($"GridsConfiguration:({string.Join(',', Grids.Select(x => $"{x.Key}:{x.Value}"))})");
        sb.AppendLine($"Important:({Important})");
        return sb.ToString();
    }
}