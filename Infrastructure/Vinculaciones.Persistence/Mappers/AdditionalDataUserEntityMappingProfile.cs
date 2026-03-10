using System;
using AutoMapper;
using PersistenceAdditionalDataUser = Vinculaciones.Persistence.Entities.AdditionalDataUser;
using DomainAdditionalDataUser = Vinculaciones.Domain.Entities.AdditionalDataUser;
namespace Vinculaciones.Persistence.Mappers;

public class AdditionalDataUserEntityMappingProfile : Profile
{
    public AdditionalDataUserEntityMappingProfile()
    {
        CreateMap<PersistenceAdditionalDataUser, DomainAdditionalDataUser>().ConvertUsing(src => new DomainAdditionalDataUser(
            src.Id,
            src.IdUsers,
            src.PrimerNombre,
            src.SegundoNombre,
            src.ApellidoPaterno,
            src.ApellidoMaterno,
            src.FechaNacimiento,
            src.IdTipoDocIden,
            src.NroDocIdentidad,
            src.NroTelefono
        ));

        CreateMap<DomainAdditionalDataUser, PersistenceAdditionalDataUser>();
    }
}
