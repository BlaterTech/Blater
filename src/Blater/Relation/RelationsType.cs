namespace Blater.Relation;

//TODO
public class RelationsType<T>
{
    public Guid Id { get; set; }
    public List<T>? Value { get; set; }
}