namespace Vinculaciones.Application.interfaces.services;

public interface IJwtService
{
    string GenerateToken(long userId, string username);
}