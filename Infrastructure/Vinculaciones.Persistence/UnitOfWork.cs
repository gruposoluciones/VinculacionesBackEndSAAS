using System;
using Microsoft.EntityFrameworkCore.Storage;
using Vinculaciones.Application.interfaces;

namespace Vinculaciones.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly VinculacionesDbContext _context;
    private IDbContextTransaction? _transaction;
    private bool _disposed;
    public UnitOfWork(VinculacionesDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync(CancellationToken ct = default)
    {
        _transaction = await _context.Database.BeginTransactionAsync(ct);
    }

    public async Task CommitTransactionAsync(CancellationToken ct = default)
    {
        if (_transaction is not null)
            await _context.Database.CommitTransactionAsync(ct);
    }
    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }
    public async Task RollbackAsync(CancellationToken ct = default)
    {
        if (_transaction is not null)
            await _context.Database.RollbackTransactionAsync(ct);
    }
    public void Dispose()
    {
        if (!_disposed)
        {
            _transaction?.Dispose();
            _context.Dispose();
            _disposed = true;
        }
    }
}
