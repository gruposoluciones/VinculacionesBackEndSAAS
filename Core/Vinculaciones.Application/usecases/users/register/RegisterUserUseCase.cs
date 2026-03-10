using System;
using AutoMapper;
using Vinculaciones.Api.common;
using Vinculaciones.Application.common;
using Vinculaciones.Application.dtos;
using Vinculaciones.Application.interfaces;
using Vinculaciones.Application.interfaces.repositories;
using Vinculaciones.Domain.Entities;

namespace Vinculaciones.Application.usecases.users.register;

public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IAdditionalDataUserRepository _additionalDataUserRepository;
    private readonly IMapper _mapper;

    public RegisterUserUseCase(
        IUserRepository userRepository,
        IAdditionalDataUserRepository additionalDataUserRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _additionalDataUserRepository = additionalDataUserRepository;
        _mapper = mapper;
    }
    public async Task<Result<RegisterUserResponse>> Execute(RegisterUserRequest request)
    {
        bool existsByEmail = await _userRepository.ExistsByEmail(request.Email);
        if (existsByEmail)
        {
            return Result<RegisterUserResponse>.Fail($"Ya existe un usuario con el email {request.Email}", ResultCode.Conflict);
        }
        bool existsByUsername = await _userRepository.ExistsByUsername(request.Username);
        if (existsByUsername)
        {
            return Result<RegisterUserResponse>.Fail($"Ya existe un usuario con el username {request.Username}", ResultCode.Conflict);
        }
        var createdUser = await _userRepository.CreateAsync(request); //Creacion de usuario

        if (createdUser == null)
        {
            return Result<RegisterUserResponse>.Fail("Error al crear usuario", ResultCode.InternalServerError);
        }
        var createdAdditionalDataUser = await _additionalDataUserRepository.AddAsync(request, createdUser.Id);
        if (createdAdditionalDataUser == null)
        {
            return Result<RegisterUserResponse>.Fail("Error al crear los datos adicionales del usuario", ResultCode.InternalServerError);
        }
        return Result<RegisterUserResponse>.Ok(new RegisterUserResponse
        {
            UserDto = _mapper.Map<UserDto>(createdUser)
        });
    }
}
