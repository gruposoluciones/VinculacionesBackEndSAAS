using System;
using Vinculaciones.Api.common;
using Vinculaciones.Application.usecases.users.login;
using Vinculaciones.Application.usecases.users.register;

namespace Vinculaciones.Application.gateways.Auth;

public class AuthGateway : IAuthGateway
{
    private readonly RegisterUserUseCase _registerUserUseCase;
    private readonly LoginUserUseCase _loginUserUseCase;
    public AuthGateway(RegisterUserUseCase registerUserUseCase,
        LoginUserUseCase loginUserUseCase
        )
    {
        _registerUserUseCase = registerUserUseCase;
        _loginUserUseCase = loginUserUseCase;
    }
    public async Task<Result<RegisterUserResponse>> Register(RegisterUserRequest request)
    {
        return await _registerUserUseCase.Execute(request);
    }
    public async Task<Result<LoginUserResponse>> Login(LoginUserRequest request)
    {
        return await _loginUserUseCase.Execute(request);
    }
}
