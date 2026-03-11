using System;
using Vinculaciones.Application.dtos.AdditionalDataUser;
using Vinculaciones.Application.usecases.users.register;
using Vinculaciones.Domain.Entities;

namespace Vinculaciones.Application.interfaces.repositories;

public interface IAdditionalDataUserRepository
{
    Task<AdditionalDataUser?> AddAsync(CreateAdditionalDataUserDto createAdditionalDataUserDto);
}
