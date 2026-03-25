
using System;
namespace Vinculaciones.Persistence.Repositories;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vinculaciones.Application.dtos.User;
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
    public async Task<User?> CreateAsync(CreateUserDto userDto)
    {
        var UserEntity = new PersistenceUser()
        {
            Username = userDto.Username,
            Email = userDto.Email,
            Password = userDto.Password,
            CreatedAt = DateTime.Now
        };
        await _context.Users.AddAsync(UserEntity);
        await _context.SaveChangesAsync();

        return _mapper.Map<User>(UserEntity);
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

    public async Task<User?> FindByEmail(string email)
    {
        var UserEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
        if (UserEntity == null)
        {
            return null;
        }
        var UserModel = _mapper.Map<User>(UserEntity);
        return UserModel;
    }

    public async Task<AuthUserDto?> FindUserForLogin(string email)
{
    /* return await _context.Set<AuthUserDto>()
    .FromSqlRaw("SELECT * FROM get_user_with_permissions({0})", email)
    .AsNoTracking()
    .FirstOrDefaultAsync(); */
    return await _context.Database
    .SqlQuery<AuthUserDto>(
        $"SELECT * FROM get_user_with_permissions({email})"
    )
    .AsNoTracking()
    .FirstOrDefaultAsync();
}
}
