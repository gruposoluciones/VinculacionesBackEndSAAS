using System;
using AutoMapper;
using Vinculaciones.Api.common;
using Vinculaciones.Application.common;
using Vinculaciones.Application.dtos;
using Vinculaciones.Application.dtos.AdditionalDataUser;
using Vinculaciones.Application.dtos.User;
using Vinculaciones.Application.interfaces;
using Vinculaciones.Application.interfaces.repositories;
using Vinculaciones.Application.interfaces.services;
using Vinculaciones.Domain.Entities;

namespace Vinculaciones.Application.usecases.users.register;

public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IAdditionalDataUserRepository _additionalDataUserRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordService _passwordService;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterUserUseCase(
        IUserRepository userRepository,
        IAdditionalDataUserRepository additionalDataUserRepository,
        IMapper mapper,
        IPasswordService passwordService,
        IUnitOfWork unitOfWork
        )
    {
        _userRepository = userRepository;
        _additionalDataUserRepository = additionalDataUserRepository;
        _mapper = mapper;
        _passwordService = passwordService;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<RegisterUserResponse>> Execute(RegisterUserRequest request)
    {
        try
        {
            bool ExistsByEmail = await _userRepository.ExistsByEmail(request.Email);
            if (ExistsByEmail)
            {
                return Result<RegisterUserResponse>.Fail($"Ya existe un usuario con el email {request.Email}", ResultCode.Conflict);
            }
            bool ExistsByUsername = await _userRepository.ExistsByUsername(request.Username);
            if (ExistsByUsername)
            {
                return Result<RegisterUserResponse>.Fail($"Ya existe un usuario con el username {request.Username}", ResultCode.Conflict);
            }
            //Inicio transaccion
            await _unitOfWork.BeginTransactionAsync();
            var PasswordHashed = _passwordService.HashPassword(request.Password);

            var CreateUserDto = new CreateUserDto()
            {
                Username = request.Username,
                Email = request.Email,
                Password = PasswordHashed
            };
            var CreatedUser = await _userRepository.CreateAsync(CreateUserDto); //Creacion de usuario
            var CreateAdditionalDataUserDto = new CreateAdditionalDataUserDto()
            {
                IdUsers = CreatedUser!.Id,
                PrimerNombre = request.PrimerNombre,
                SegundoNombre = request.SegundoNombre,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                FechaNacimiento = request.FechaNacimiento,
                IdTipoDocIden = request.IdTipoDocIden,
                NroDocIdentidad = request.NroDocIdentidad,
                NroTelefono = request.NroTelefono
            };
            var CreatedAdditionalDataUser = await _additionalDataUserRepository.AddAsync(CreateAdditionalDataUserDto);

            await _unitOfWork.CommitTransactionAsync();
            _unitOfWork.Dispose();
            //Fin transaccion

            return Result<RegisterUserResponse>.Ok(new RegisterUserResponse
            {
                UserDto = _mapper.Map<UserDto>(CreatedUser)
            });
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            return Result<RegisterUserResponse>.Fail("Hubo un error al crear el usuario.", ResultCode.InternalServerError);
        }
    }
}
