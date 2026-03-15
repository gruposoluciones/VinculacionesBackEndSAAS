using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Vinculaciones.Application.interfaces.repositories;
using Vinculaciones.Application.interfaces.services;
using Vinculaciones.Persistence.Mappers;
using Vinculaciones.Persistence.Repositories;
using Vinculaciones.Persistence.Services;
using Vinculaciones.Application.interfaces.services;
using Vinculaciones.Persistence.Services;

namespace Vinculaciones.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserEntityMappingProfile).Assembly);

        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdditionalDataUserRepository, AdditionalDataUserRepository>();

        //Services
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}
