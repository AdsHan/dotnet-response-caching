using Microsoft.AspNetCore.Mvc;
using ResponseCaching.API.Application.Messages.Commands;
using ResponseCaching.API.Data.Repositories;
namespace ResponseCaching.API.Cache.DecoratorPattern;

public static class CacheResponseCachingConfig
{
    public static IServiceCollection AddCacheResponseCachingConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options =>
        {
            options.CacheProfiles.Add("Default",
              new CacheProfile() { Duration = 10 }
            );
            options.CacheProfiles.Add("Client",
              new CacheProfile() { Location = ResponseCacheLocation.Client, Duration = 100 }
            );
        });

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddResponseCaching(options =>
        {
            options.UseCaseSensitivePaths = true;
            options.MaximumBodySize = 1024;
        });

        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
        });

        return services;
    }

    public static WebApplication UseCacheResponseCachingConfiguration(this WebApplication app)
    {
        app.UseResponseCaching();

        return app;
    }
}
