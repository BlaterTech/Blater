namespace Blater.Query.Interfaces;

public interface IBlaterQueryable<out T> : IQueryable<T> where T : BaseDataModel
{

}