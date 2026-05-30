namespace ECommerce.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string PasswordHash { get; private set; } = string.Empty;

    public string Role { get; private set; } = "User";

    public DateTime CreatedAt { get; private set; }

    private User() { }

    public User(
        string name,
        string email,
        string passwordHash,
        string role)
    {
        Id = Guid.NewGuid();

        Name = name;

        Email = email;

        PasswordHash = passwordHash;

        Role = role;

        CreatedAt = DateTime.UtcNow;
    }
}