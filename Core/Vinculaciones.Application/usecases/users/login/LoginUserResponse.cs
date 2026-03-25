using System;

namespace Vinculaciones.Application.usecases.users.login;

public class LoginUserResponse
{
    public long Id { get; set; }
    public string Username { get; set; } = null!;
    public string Token { get; set; } = default!;
    public string Roles { get; set; } = null!;
    public string Establishments { get; set; } = null!;
    public string Menus {get;set;} = null!;
}
