using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // add services to the IoC container here
        // core services often include domain logic, business rules and other higher-level components

        services.AddScoped<IUsersService, UsersService>();
        return services;
    }
}