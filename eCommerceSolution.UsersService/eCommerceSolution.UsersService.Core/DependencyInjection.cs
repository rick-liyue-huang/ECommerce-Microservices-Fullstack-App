using eCommerceSolution.UsersService.Core.ServiceContracts;
using eCommerceSolution.UsersService.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceSolution.UsersService.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, Services.UsersService>();
        
        return services;
    }
}