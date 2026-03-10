using System;
using Vinculaciones.Application.usecases.users.register;
using Vinculaciones.Domain.Entities;

namespace Vinculaciones.Application.interfaces.repositories;

public interface IUserRepository
{
    Task<bool> ExistsByEmail(string email);
    Task<bool> ExistsByUsername(string username);
    Task<User?> CreateAsync(RegisterUserRequest request);
}
