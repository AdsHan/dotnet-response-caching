using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ResponseCaching.API.Cache.DecoratorPattern;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var objectString = await _distributedCache.GetStringAsync(key);

        if (string.IsNullOrWhiteSpace(objectString))
        {
            return default(T);
        }

        return JsonConvert.DeserializeObject<T>(objectString);
    }

    public async Task SetAsync<T>(string key, T data)
    {
        var objectString = JsonConvert.SerializeObject(data);

        await _distributedCache.SetStringAsync(key, objectString, GetCacheOptions());
    }

    public async Task<T> GetOrSetAsync<T>(string key, TimeSpan expiration, Func<Task<T>> getData)
    {
        var objectString = await _distributedCache.GetStringAsync(key);

        if (string.IsNullOrWhiteSpace(objectString))
        {
            objectString = JsonConvert.SerializeObject(await getData());

            await _distributedCache.SetStringAsync(key, objectString, GetCacheOptions(expiration));
        }

        return JsonConvert.DeserializeObject<T>(objectString);
    }

    private DistributedCacheEntryOptions GetCacheOptions(TimeSpan? expiration = null)
    {
        var memoryCacheEntryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromSeconds(3600),
        };

        return memoryCacheEntryOptions;
    }

}