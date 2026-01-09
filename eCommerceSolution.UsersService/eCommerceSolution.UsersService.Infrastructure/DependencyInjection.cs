using eCommerceSolution.UsersService.Domain.RepositoryContracts;
using eCommerceSolution.UsersService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceSolution.UsersService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
        
        return services;
    }
}