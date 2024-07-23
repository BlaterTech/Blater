using System.Threading.Tasks;
using Blater.Models.Bases;

namespace Blater.Interfaces;

public interface IBlaterCache
{
    Task Set<TValue>(string key, TValue value) where TValue : BaseDataModel;
    Task Remove(string key);
}