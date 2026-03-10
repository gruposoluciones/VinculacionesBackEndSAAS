using System;

namespace Vinculaciones.Application.usecases.users.register;

public class RegisterUserRequest
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? PrimerNombre { get; set; }
    public string? SegundoNombre { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
    public DateOnly? FechaNacimiento { get; set; }
    public long? IdTipoDocIden { get; set; }
    public string? NroDocIdentidad { get; set; }
    public string? NroTelefono { get; set; }
}
