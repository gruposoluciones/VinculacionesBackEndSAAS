using System;
using AutoMapper;
using Vinculaciones.Domain.Entities;
using Vinculaciones.Application.usecases.users.register;
using Vinculaciones.Application.interfaces.repositories;
using AdditionalDataUserEntity = Vinculaciones.Persistence.Entities.AdditionalDataUser;
using Vinculaciones.Application.dtos.AdditionalDataUser;

namespace Vinculaciones.Persistence.Repositories;

public class AdditionalDataUserRepository : IAdditionalDataUserRepository
{
    private readonly VinculacionesDbContext _context;
    private readonly IMapper _mapper;
    public AdditionalDataUserRepository(VinculacionesDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<AdditionalDataUser?> AddAsync(CreateAdditionalDataUserDto createAdditionalDataUserDto)
    {
        var AdditionalDataUserEntity = new AdditionalDataUserEntity()
        {
            IdUsers = createAdditionalDataUserDto.IdUsers,
            PrimerNombre = createAdditionalDataUserDto.PrimerNombre,
            SegundoNombre = createAdditionalDataUserDto.SegundoNombre,
            ApellidoPaterno = createAdditionalDataUserDto.ApellidoPaterno,
            ApellidoMaterno = createAdditionalDataUserDto.ApellidoMaterno,
            FechaNacimiento = createAdditionalDataUserDto.FechaNacimiento,
            IdTipoDocIden = createAdditionalDataUserDto.IdTipoDocIden,
            NroDocIdentidad = createAdditionalDataUserDto.NroDocIdentidad,
            NroTelefono = createAdditionalDataUserDto.NroTelefono
        };
        await _context.AdditionalDataUsers.AddAsync(AdditionalDataUserEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<AdditionalDataUser>(AdditionalDataUserEntity);
    }
}
