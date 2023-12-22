using Microsoft.Extensions.Caching.StackExchangeRedis;
using ResponseCaching.API.Application.Messages.Commands;
using ResponseCaching.API.Data.Repositories;

namespace ResponseCaching.API.Cache.DecoratorPattern;

public static class CacheDecoratorPatternConfig
{
    public static IServiceCollection AddCacheDecoratorPatternConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddStackExchangeRedisCache(delegate (RedisCacheOptions options)
        {
            options.InstanceName = "CacheStorage";
            options.Configuration = configuration.GetConnectionString("RedisCs");
        });

        services.AddTransient<ICacheService, CacheService>();

        services.AddScoped<ProductRepository>();
        services.AddScoped<IProductRepository, CacheProductRepositoryDecorator<ProductRepository>>();

        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
        });

        return services;
    }
}
