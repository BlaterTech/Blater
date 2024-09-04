namespace Blater.Extensions;

public static class DictionaryExtensions
{
    public static TValue? GetHasFlagValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Enum @enum)
        where TKey : Enum
        where TValue : notnull
    {
        var value = dictionary
                   .FirstOrDefault(x => x.Key.HasFlag(@enum))
                   .Value;

        return value;
    }
}