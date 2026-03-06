using System;

namespace Vinculaciones.Domain.Entities;

public class UserEstablishment
{
    public long UserId { get; private set; }
    public long EstablecimientoId { get; private set; }
    public bool Enabled { get; private set; }

    // Relaciones de navegación
    public virtual User User { get; private set; } = null!;
    public virtual Establishment Establecimiento { get; private set; } = null!;
    public UserEstablishment(long userId,
        long establecimientoId,
        bool enabled = true)
    {
        UserId = userId;
        EstablecimientoId = establecimientoId;
        Enabled = enabled;
    }
}