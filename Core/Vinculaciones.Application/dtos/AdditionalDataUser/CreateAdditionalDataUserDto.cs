using System;

namespace Vinculaciones.Application.dtos.AdditionalDataUser;

public class CreateAdditionalDataUserDto
{
    public long IdUsers { get; set; }
    public string? PrimerNombre { get; set; }
    public string? SegundoNombre { get; set; }
    public string? ApellidoPaterno { get; set; }
    public string? ApellidoMaterno { get; set; }
    public DateOnly? FechaNacimiento { get; set; }
    public long? IdTipoDocIden { get; set; }
    public string? NroDocIdentidad { get; set; }
    public string? NroTelefono { get; set; }
}
