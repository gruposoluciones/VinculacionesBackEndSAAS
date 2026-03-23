using System;
using AutoMapper;
using PersistenceUser = Vinculaciones.Persistence.Entities.User;
using DomainUser = Vinculaciones.Domain.Entities.User;
namespace Vinculaciones.Persistence.Mappers;

public class UserEntityMappingProfile : Profile
{
    public UserEntityMappingProfile()
    {
        CreateMap<PersistenceUser, DomainUser>().ConstructUsing(src => new DomainUser(
            src.Id,
            src.Username,
            src.Email,
            src.Password,
            src.CreatedAt ?? DateTime.UtcNow,
            src.FirstSession ?? false,
            src.Enabled ?? true
        ));

        CreateMap<DomainUser, PersistenceUser>();
    }
}
