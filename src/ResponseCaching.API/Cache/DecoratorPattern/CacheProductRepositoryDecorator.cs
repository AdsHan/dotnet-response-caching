using ResponseCaching.API.Data.Entities;
using ResponseCaching.API.Data.Repositories;

namespace ResponseCaching.API.Cache.DecoratorPattern;

public class CacheProductRepositoryDecorator<T> : IProductRepository where T : IProductRepository
{
    private readonly ICacheService _cache;
    private readonly T _inner;

    public CacheProductRepositoryDecorator(ICacheService cacheService, T inner)
    {
        _cache = cacheService;
        _inner = inner;
    }

    public void Dispose()
    {
        _inner.Dispose();
    }

    public Task SaveAsync()
    {
        return _inner.SaveAsync();
    }

    public void Add(ProductModel obj)
    {
        _inner.Add(obj);
    }

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var key = "GetAll-Decorate";

        var products = await _cache.GetAsync<IEnumerable<ProductModel>>(key);

        if (products == null)
        {
            products = await _inner.GetAllAsync();
            if (products != null)
            {
                await _cache.SetAsync(key, products);
            }
        }

        return products;
    }
}