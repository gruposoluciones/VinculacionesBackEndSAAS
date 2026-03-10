using System;
using AutoMapper;
using Vinculaciones.Domain.Entities;
using Vinculaciones.Application.usecases.users.register;
using Vinculaciones.Application.interfaces.repositories;
using AdditionalDataUserEntity = Vinculaciones.Persistence.Entities.AdditionalDataUser;

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
    public async Task<AdditionalDataUser?> AddAsync(RegisterUserRequest request, long idUser)
    {
        var AdditionalDataUserEntity = new AdditionalDataUserEntity()
        {
            IdUsers = idUser,
            PrimerNombre = request.PrimerNombre,
            SegundoNombre = request.SegundoNombre,
            ApellidoPaterno = request.ApellidoPaterno,
            ApellidoMaterno = request.ApellidoMaterno,
            FechaNacimiento = request.FechaNacimiento,
            IdTipoDocIden = request.IdTipoDocIden,
            NroDocIdentidad = request.NroDocIdentidad,
            NroTelefono = request.NroTelefono
        };
        await _context.AdditionalDataUsers.AddAsync(AdditionalDataUserEntity);
        await _context.SaveChangesAsync();
        var AdditionalDataUserModel = _mapper.Map<AdditionalDataUser>(AdditionalDataUserEntity);
        return AdditionalDataUserModel;
    }
}
