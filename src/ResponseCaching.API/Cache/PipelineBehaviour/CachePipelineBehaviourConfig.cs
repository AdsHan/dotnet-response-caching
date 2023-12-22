using Microsoft.Extensions.Caching.StackExchangeRedis;
using ResponseCaching.API.Application.Messages.Behaviors;
using ResponseCaching.API.Application.Messages.Commands;
using ResponseCaching.API.Data.Repositories;

namespace ResponseCaching.API.Cache.DecoratorPattern;

public static class CachePipelineBehaviourConfig
{
    public static IServiceCollection AddCachePipelineBehaviourConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddStackExchangeRedisCache(delegate (RedisCacheOptions options)
        {
            options.InstanceName = "CacheStorage";
            options.Configuration = configuration.GetConnectionString("RedisCs");
        });

        services.AddSingleton<ICacheService, CacheService>();

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
            x.AddOpenBehavior(typeof(CacheResponseBehavior<,>));
        });

        return services;
    }
}
