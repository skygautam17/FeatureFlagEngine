
using System.Collections.Concurrent;

public class InMemoryFeatureCache
{
    private static readonly ConcurrentDictionary<string, bool> _cache = new();

    public bool? Get(string key)
    {
        return _cache.TryGetValue(key, out var value) ? value : null;
    }

    public void Set(string key, bool value)
    {
        _cache[key] = value;
    }

    public void Remove(string key)
    {
        _cache.TryRemove(key, out _);
    }
}
