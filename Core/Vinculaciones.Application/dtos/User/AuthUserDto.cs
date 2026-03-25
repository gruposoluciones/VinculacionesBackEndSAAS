using System;
namespace Vinculaciones.Application.dtos.User;
public class AuthUserDto
{
    public long UserId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Roles { get; set; } = null!;
    public string Establishments { get; set; } = null!;
    public string Menus {get;set;} = null!;
}