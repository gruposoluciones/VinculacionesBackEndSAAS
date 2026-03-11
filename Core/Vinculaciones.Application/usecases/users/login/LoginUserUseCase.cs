using System;
using Vinculaciones.Api.common;
using Vinculaciones.Application.common;
using Vinculaciones.Application.interfaces.repositories;
using Vinculaciones.Application.interfaces.services;

namespace Vinculaciones.Application.usecases.users.login;

public class LoginUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    public LoginUserUseCase(IUserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }
    public async Task<Result<LoginUserResponse>> Execute(LoginUserRequest request)
    {
        var user = await _userRepository.FindByEmail(request.Email);
        if (user == null)
        {
            return Result<LoginUserResponse>.Fail("Credenciales inválidas", ResultCode.Unauthorized);
        }
        if (!_passwordService.VerifyPassword(request.Password, user.Password))
        {
            return Result<LoginUserResponse>.Fail("Credenciales inválidas", ResultCode.Unauthorized);
        }
        return Result<LoginUserResponse>.Ok(new LoginUserResponse
        {
            Id = user.Id,
            Username = user.Username
        });
    }
}
