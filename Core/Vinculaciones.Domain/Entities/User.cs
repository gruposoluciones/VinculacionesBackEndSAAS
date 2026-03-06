namespace Vinculaciones.Domain.Entities;

public class User
{
    public long Id { get; private set; }
    public string Username { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public bool FirstSession { get; private set; }
    public bool Enabled { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User(long id,
        string username,
        string email,
        string password,
        DateTime createdAt,
        bool firstSession = false,
        bool enabled = true)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        FirstSession = firstSession;
        Enabled = enabled;
        CreatedAt = createdAt;
    }
}
