using System;

namespace Vinculaciones.Application.interfaces.services;

public interface IPasswordService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string passwordHashed);
}
