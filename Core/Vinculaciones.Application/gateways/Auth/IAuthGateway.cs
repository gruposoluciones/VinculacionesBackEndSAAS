using System;
using Vinculaciones.Api.common;
using Vinculaciones.Application.usecases.users.login;
using Vinculaciones.Application.usecases.users.register;

namespace Vinculaciones.Application.gateways;

public interface IAuthGateway
{
    Task<Result<RegisterUserResponse>> Register(RegisterUserRequest request);
    Task<Result<LoginUserResponse>> Login(LoginUserRequest request);
}
