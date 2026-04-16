using System;

namespace Vinculaciones.Application.dtos.User;

public class PesquisaUserDto
{
    public long UserId { get; set; }
    public string Nombres { get; set; } = null!;
    public string ApellidoPaterno { get; set; } = null!;
    public string ApellidoMaterno { get; set; } = null!;
}
