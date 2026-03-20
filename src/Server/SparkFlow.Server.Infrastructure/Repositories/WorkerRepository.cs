// -----------------------------------------------------------------------------
// File: WorkerRepository.cs
// Path: ./src/Server/SparkFlow.Server.Infrastructure/Repositories/WorkerRepository.cs
// Summary:
//   Entity Framework implementation of the worker repository.
//
// Responsibilities:
//   - Persist workers
//   - Query workers
//   - Save pending changes
// -----------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using SparkFlow.Server.Domain.Interfaces;
using SparkFlow.Server.Domain.Workers;
using SparkFlow.Server.Infrastructure.Persistence;

namespace SparkFlow.Server.Infrastructure.Repositories;

public sealed class WorkerRepository : IWorkerRepository
{
    private readonly AppDbContext _context;

    public WorkerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Worker worker)
    {
        await _context.Workers.AddAsync(worker);
    }

    public async Task<Worker?> GetByIdAsync(Guid workerId)
    {
        return await _context.Workers.FindAsync(workerId);
    }

    public async Task<Worker?> GetByKeyAsync(string workerKey)
    {
        return await _context.Workers.FirstOrDefaultAsync(x => x.WorkerKey == workerKey);
    }

    public async Task<List<Worker>> GetAllAsync()
    {
        return await _context.Workers.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
