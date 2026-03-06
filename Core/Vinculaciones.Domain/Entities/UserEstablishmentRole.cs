using System;

namespace Vinculaciones.Domain.Entities;

public class UsersEstablishmentsRole
{
    public long UserId { get; private set; }
    public long EstablecimientoId { get; private set; }
    public long RoleId { get; private set; }
    public bool Enabled { get; private set; }

    // Relaciones de navegación
    public virtual User User { get; private set; } = null!;
    public virtual Establishment Establecimiento { get; private set; } = null!;
    public virtual Role Role { get; private set; } = null!;

    public UsersEstablishmentsRole(long userId,
        long establecimientoId,
        long roleId,
        bool enabled = true)
    {
        UserId = userId;
        EstablecimientoId = establecimientoId;
        RoleId = roleId;
        Enabled = enabled;
    }
}