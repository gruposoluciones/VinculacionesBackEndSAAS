
using System;
namespace Vinculaciones.Persistence.Repositories;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vinculaciones.Application.interfaces.repositories;
using Vinculaciones.Application.usecases.users.register;
using Vinculaciones.Domain.Entities;
using PersistenceUser = Persistence.Entities.User;

public class UserRepository : IUserRepository
{
    private readonly VinculacionesDbContext _context;
    private readonly IMapper _mapper;
    public UserRepository(VinculacionesDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<User?> CreateAsync(RegisterUserRequest request)
    {
        var UserEntity = new PersistenceUser()
        {
            Username = request.Username,
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            CreatedAt = DateTime.Now
        };
        await _context.Users.AddAsync(UserEntity);
        await _context.SaveChangesAsync();

        var UserModel = _mapper.Map<User>(UserEntity);
        return UserModel;
    }

    public async Task<bool> ExistsByEmail(string email)
    {
        bool existEmail = await _context.Users.AnyAsync(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
        return existEmail;
    }

    public async Task<bool> ExistsByUsername(string username)
    {
        bool existUsername = await _context.Users.AnyAsync(u => u.Username.ToLower().Trim() == username.ToLower().Trim());
        return existUsername;
    }
}
