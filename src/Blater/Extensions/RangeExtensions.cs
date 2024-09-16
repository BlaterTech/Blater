namespace Blater.Extensions;

public static class RangeExtensions
{
    public static CustomEnumerator GetEnumerator(this Range range)
    {
        return new CustomEnumerator(range);
    }

    public static CustomEnumerator GetEnumerator(this int range)
    {
        return new CustomEnumerator(new Range(0, range));
    }
}

public ref struct CustomEnumerator
{
    public CustomEnumerator(Range range)
    {
        if (range.End.IsFromEnd)
        {
            throw new Exception("Cannot iterate from end");
        }

        Current = range.Start.Value - 1;
        _end = range.End.Value;
    }

    public int Current { get; private set; }

    private readonly int _end;

    public bool MoveNext()
    {
        Current++;
        return Current <= _end;
    }
}