﻿using PeopleDeskHrm.Application.Contracts.Persistences.IRepositories;

namespace PeopleDeskHrm.Application.Contracts.Persistences;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    IEmployeeRepository EmployeeRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
