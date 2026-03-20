// -----------------------------------------------------------------------------
// File: WorkerAssignmentEngine.cs
// Path: ./src/Server/SparkFlow.Server.Application/Workers/Services/WorkerAssignmentEngine.cs
// Summary:
//   Provides basic worker assignment helpers.
//
// Responsibilities:
//   - Return available worker candidates
//
// Notes:
//   - This is intentionally simple for the first server MVP.
// -----------------------------------------------------------------------------

using SparkFlow.Server.Domain.Interfaces;
using SparkFlow.Server.Domain.Workers;

namespace SparkFlow.Server.Application.Workers.Services;

public sealed class WorkerAssignmentEngine
{
    private readonly IWorkerRepository _repository;

    public WorkerAssignmentEngine(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Worker>> GetAvailableWorkers()
    {
        return await _repository.GetAllAsync();
    }
}
