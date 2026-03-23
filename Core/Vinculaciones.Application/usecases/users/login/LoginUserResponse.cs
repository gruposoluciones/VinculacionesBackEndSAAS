using System;

namespace Vinculaciones.Application.usecases.users.login;

public class LoginUserResponse
{
    public long Id { get; set; }
    public string Username { get; set; } = null!;
    public string Token { get; set; } = default!;
    public string Role { get; set; } = null!;
    public long RoleId { get; set; }
    public long EstablishmentId { get; set; }
}
