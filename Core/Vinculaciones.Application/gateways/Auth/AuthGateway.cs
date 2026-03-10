using System;
using Vinculaciones.Api.common;
using Vinculaciones.Application.usecases.users.register;

namespace Vinculaciones.Application.gateways.Auth;

public class AuthGateway : IAuthGateway
{
    private readonly RegisterUserUseCase _registerUserUseCase;
    public AuthGateway(RegisterUserUseCase registerUserUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
    }
    public async Task<Result<RegisterUserResponse>> Register(RegisterUserRequest request)
    {
        return await _registerUserUseCase.Execute(request);
    }
}
