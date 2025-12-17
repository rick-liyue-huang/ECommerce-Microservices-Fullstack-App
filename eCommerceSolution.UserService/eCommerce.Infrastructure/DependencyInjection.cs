using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // extension methods to add infrastructure services to the DI container
        // add services to the IoC container here
        // infrastructure services often include data access, caching and other lower-level components
        // e.g. services.AddEntityFrameworkSqlServer();
        return services;
    }
}