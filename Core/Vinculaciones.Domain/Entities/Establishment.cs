using System;

namespace Vinculaciones.Domain.Entities;

public class Establishment
{
    public long Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Address { get; private set; }
    public bool Enabled { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Establishment(long id,
        string name,
        DateTime createdAt,
        string? address = null,
        bool enabled = true)
    {
        Id = id;
        Name = name;
        Address = address;
        Enabled = enabled;
        CreatedAt = createdAt;
    }
}