namespace ResponseCaching.API.Cache.DecoratorPattern;

public interface ICacheService
{
    Task<T> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T data);
    Task<T> GetOrSetAsync<T>(string key, TimeSpan expiration, Func<Task<T>> getData);
}