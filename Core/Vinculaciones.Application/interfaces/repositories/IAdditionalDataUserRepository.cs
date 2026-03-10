using System;
using Vinculaciones.Application.usecases.users.register;
using Vinculaciones.Domain.Entities;

namespace Vinculaciones.Application.interfaces.repositories;

public interface IAdditionalDataUserRepository
{
    Task<AdditionalDataUser?> AddAsync(RegisterUserRequest request, long idUser);
}
