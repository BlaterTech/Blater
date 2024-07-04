using System.Collections;
using System.Dynamic;

namespace Blater.Query.Models;

/// <summary>
/// defult implementation of a Dynamic object, inherit off this for dyanmic properties
/// </summary>
public class DynamicDictionary : DynamicObject, IDictionary<string, object?>
{
    private readonly Dictionary<string, object?> _dictionary = new();

    public void SetKey(string name, object? value)
    {
        var key = GetKey(name);
        _dictionary[key] = value;
    }

    public override bool TryGetMember(
        GetMemberBinder binder, out object? result)
    {
        var key = GetKey(binder.Name);
        return _dictionary.TryGetValue(key, out result);
    }

    public override bool TrySetMember(
        SetMemberBinder binder, object? value)
    {
        SetKey(binder.Name, value);
        return true;
    }

    public bool ContainsKey(string key)
    {
        return _dictionary.ContainsKey(key);
    }

    public void Add(string key, object? value)
    {
        _dictionary.Add(key, value);
    }

    public bool Remove(string key)
    {
        return _dictionary.Remove(key);
    }

    public bool TryGetValue(string key, out object? value)
    {
        return _dictionary.TryGetValue(key, out value!);
    }

    public object? this[string index]
    {
        get => _dictionary.GetValueOrDefault(index);
        set => SetKey(index, value);
    }

    public ICollection<string> Keys => _dictionary.Keys;
    public ICollection<object?> Values => _dictionary.Values;

    protected virtual string GetKey(string key)
    {
        return key;
    }

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
    {
        return _dictionary.GetEnumerator();
    }

    public override string? ToString()
    {
        return _dictionary.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(KeyValuePair<string, object?> item)
    {
        _dictionary.Add(item.Key, item.Value);
    }

    public void Clear()
    {
        _dictionary.Clear();
    }

    public bool Contains(KeyValuePair<string, object?> item)
    {
        return _dictionary.ContainsKey(item.Key);
    }

    public void CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex)
    {
        ((ICollection<KeyValuePair<string, object?>>)_dictionary).CopyTo(array, arrayIndex);
    }

    public bool Remove(KeyValuePair<string, object?> item)
    {
        return _dictionary.Remove(item.Key);
    }

    public int Count => _dictionary.Count;
    public bool IsReadOnly => false;
}