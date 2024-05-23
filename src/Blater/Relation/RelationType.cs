namespace Blater.Relation;

//TODO
public class RelationType<T>
{
    public Guid Id { get; set; }
    public T? Value { get; set; }
}