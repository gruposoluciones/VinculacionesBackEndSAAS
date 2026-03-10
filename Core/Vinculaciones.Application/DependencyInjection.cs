using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Vinculaciones.Application.gateways;
using Vinculaciones.Application.gateways.Auth;
using Vinculaciones.Application.mappers;
using Vinculaciones.Application.usecases.users.register;
namespace Vinculaciones.Application;

// Application/DependencyInjection.cs   
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var useCases = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.Name.EndsWith("UseCase") && t.IsClass && !t.IsAbstract);

        foreach (var useCase in useCases)
            services.AddScoped(useCase);

        services.AddScoped<IAuthGateway, AuthGateway>();
        services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
        return services;
    }
}
