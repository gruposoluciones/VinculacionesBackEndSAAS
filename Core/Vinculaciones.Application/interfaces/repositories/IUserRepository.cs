using System;
using Vinculaciones.Application.dtos.User;
using Vinculaciones.Application.usecases.users.register;
using Vinculaciones.Domain.Entities;

namespace Vinculaciones.Application.interfaces.repositories;

public interface IUserRepository
{
    Task<bool> ExistsByEmail(string email);
    Task<bool> ExistsByUsername(string username);
    Task<User?> CreateAsync(CreateUserDto request);
    Task<User?> FindByEmail(string email);
    Task<AuthUserDto?> FindUserForLogin(string email);
}
