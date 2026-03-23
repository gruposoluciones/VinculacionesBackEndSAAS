using System;

namespace Vinculaciones.Application.interfaces;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransactionAsync(CancellationToken ct = default);
    Task CommitTransactionAsync(CancellationToken ct = default);
    Task<int> SaveChangesAsync(CancellationToken ct = default);
    Task RollbackAsync(CancellationToken ct = default);
}
