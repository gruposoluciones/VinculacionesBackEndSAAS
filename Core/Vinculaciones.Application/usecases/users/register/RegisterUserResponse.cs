using System;
using Vinculaciones.Application.dtos;
using Vinculaciones.Domain.Entities;

namespace Vinculaciones.Application.usecases.users.register;

public class RegisterUserResponse
{
    public UserDto UserDto { get; set; } = null!;
}
