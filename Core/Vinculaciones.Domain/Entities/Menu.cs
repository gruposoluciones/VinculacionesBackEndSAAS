using System;

namespace Vinculaciones.Domain.Entities;

public class Menu
{
    public long Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Route { get; private set; }
    public string? Icon { get; private set; }
    public long? ParentId { get; private set; }
    public bool Enabled { get; private set; }

    // Relaciones de navegación
    public virtual ICollection<Menu> SubMenus { get; set; } = new List<Menu>();
    public virtual Menu? ParentMenu { get; set; }

    public Menu(long id,
        string name,
        string? route = null,
        string? icon = null,
        long? parentId = null,
        bool enabled = true)
    {
        Id = id;
        Name = name;
        Route = route;
        Icon = icon;
        ParentId = parentId;
        Enabled = enabled;
    }
}