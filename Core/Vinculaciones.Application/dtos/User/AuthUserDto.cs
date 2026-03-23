using System;
namespace Vinculaciones.Application.dtos.User;
public class AuthUserDto
{
    public long UserId { get; set; }
    public string Email{get;set;} = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public long RoleId { get; set; }
    public string RoleName { get; set; } = null!;

    public long EstablishmentId { get; set; }
}