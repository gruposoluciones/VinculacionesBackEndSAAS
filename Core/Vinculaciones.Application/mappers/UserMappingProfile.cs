using System;
using AutoMapper;
using Vinculaciones.Application.dtos;
using Vinculaciones.Domain.Entities;

namespace Vinculaciones.Application.mappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}
