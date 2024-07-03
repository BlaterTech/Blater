using Blater.AutoModelConfigurations;
using Blater.AutoModelConfigurations.Interfaces;

namespace Blater.Models.Bases;

public abstract class BaseFrontendModel : BaseDataModel, IDataModelConfigurator
{
    public abstract void Configure(AutoModelConfigurator configurator);
}