using Vinculaciones.Domain.Entities;

public class TiposDocIdentidad
{
    public string Id { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string DescriptionCorta { get; private set; } = null!;
    public bool Enabled { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public TiposDocIdentidad(string id,
        string name,
        string description,
        string descriptionCorta,
        DateTime createdAt,
        bool enabled = true)
    {
        Id = id;
        Name = name;
        Description = description;
        DescriptionCorta = descriptionCorta;
        Enabled = enabled;
        CreatedAt = createdAt;
    }
}