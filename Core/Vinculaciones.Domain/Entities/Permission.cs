using System;

namespace Vinculaciones.Domain.Entities;

public class Permission
{
    public long Id { get; private set; }
    public long RoleId { get; private set; }
    public long MenuId { get; private set; }
    public bool? Read { get; private set; }
    public bool? Created { get; private set; }
    public bool? Updated { get; private set; }
    public bool? Deleted { get; private set; }
    public bool? Allowed { get; private set; }

    // Relaciones de navegación
    public virtual Role Role { get; private set; } = null!;
    public virtual Menu Menu { get; private set; } = null!;

    public Permission(long id,
        long roleId,
        long menuId,
        bool? read = null,
        bool? created = null,
        bool? updated = null,
        bool? deleted = null,
        bool? allowed = null)
    {
        Id = id;
        RoleId = roleId;
        MenuId = menuId;
        Read = read;
        Created = created;
        Updated = updated;
        Deleted = deleted;
        Allowed = allowed;
    }
}
