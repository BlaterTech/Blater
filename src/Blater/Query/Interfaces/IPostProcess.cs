namespace Blater.Query.Interfaces;

public interface IPostProcess
{
    object? Execute<T>(IEnumerable<T?> items);
}