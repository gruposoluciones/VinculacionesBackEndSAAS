using System;

namespace Vinculaciones.Application.usecases.users.login;

public class LoginUserRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public long EstablishmentId { get; set; }
}
