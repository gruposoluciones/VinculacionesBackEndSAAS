using System;
using Microsoft.EntityFrameworkCore;
using Vinculaciones.Application.interfaces.repositories;

namespace Vinculaciones.Persistence.Repositories;

public class EstablishmentRepository : IEstablishmentRepository
{
    private readonly VinculacionesDbContext _context;
    public EstablishmentRepository(VinculacionesDbContext db)
    {
        _context = db;
    }
    public async Task<bool> existsById(int idEstablishment)
    {
        var exists = await _context.Establishments.AnyAsync(e => e.Id == idEstablishment);
        return exists;
    }
}
