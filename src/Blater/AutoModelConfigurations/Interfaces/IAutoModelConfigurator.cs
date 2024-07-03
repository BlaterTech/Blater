using System.Linq.Expressions;
using Blater.Enumerations.AutoModel;

namespace Blater.AutoModelConfigurations.Interfaces;

public interface IAutoModelConfigurator
{
    IAutoModelConfigurator Model { get; }
    IAutoComponentPropertyConfigurator Property<TProperty>(Expression<Func<TProperty>> propertyExpression);
    IAutoModelConfigurator GridType(AutoGridType gridType);
    IAutoModelConfigurator CanBeDisabled(bool value);
}