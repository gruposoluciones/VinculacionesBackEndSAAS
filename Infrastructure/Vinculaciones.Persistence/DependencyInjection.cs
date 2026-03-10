using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Vinculaciones.Application.interfaces.repositories;
using Vinculaciones.Persistence.Mappers;
using Vinculaciones.Persistence.Repositories;

namespace Vinculaciones.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserEntityMappingProfile).Assembly);

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdditionalDataUserRepository, AdditionalDataUserRepository>();

        return services;
    }
}
