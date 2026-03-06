using System;

namespace Vinculaciones.Domain.Entities;

public class Role
{
    public long Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public bool Enabled { get; private set; }

    public Role(long id,
        string name,
        string? description = null,
        bool enabled = true)
    {
        Id = id;
        Name = name;
        Description = description;
        Enabled = enabled;
    }
}
