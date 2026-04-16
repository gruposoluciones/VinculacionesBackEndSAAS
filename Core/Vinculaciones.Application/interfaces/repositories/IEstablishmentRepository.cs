using System;

namespace Vinculaciones.Application.interfaces.repositories;

public interface IEstablishmentRepository
{
    Task<bool> existsById(int idEstablishment);
}
