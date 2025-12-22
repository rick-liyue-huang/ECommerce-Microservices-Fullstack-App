using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.Validators;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace BusinessLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, 
            typeof(ProductToProductResponseMappingProfile).Assembly);
        
        return services;
    }
}