// -----------------------------------------------------------------------------
// File: IWorkerRepository.cs
// Path: ./src/Server/SparkFlow.Server.Domain/Interfaces/IWorkerRepository.cs
// Summary:
//   Repository contract for worker persistence.
//
// Responsibilities:
//   - Add workers
//   - Retrieve workers
//   - Save changes
// -----------------------------------------------------------------------------

using SparkFlow.Server.Domain.Workers;

namespace SparkFlow.Server.Domain.Interfaces;

public interface IWorkerRepository
{
    Task AddAsync(Worker worker);

    Task<Worker?> GetByIdAsync(Guid workerId);

    Task<Worker?> GetByKeyAsync(string workerKey);

    Task<List<Worker>> GetAllAsync();

    Task SaveChangesAsync();
}
