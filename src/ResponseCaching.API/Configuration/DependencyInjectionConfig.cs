using Microsoft.EntityFrameworkCore;
using ResponseCaching.API.Application.Services;
using ResponseCaching.API.Data;

namespace ResponseCaching.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services)
    {
        services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("CatalogDB"));

        services.AddTransient<ProductPopulateService>();

        return services;
    }
}
