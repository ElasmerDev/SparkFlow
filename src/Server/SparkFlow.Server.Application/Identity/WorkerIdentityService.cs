// -----------------------------------------------------------------------------
// File: WorkerIdentityService.cs
// Path: ./src/Server/SparkFlow.Server.Application/Identity/WorkerIdentityService.cs
// Summary:
//   Validates worker identity against persistence storage.
//
// Responsibilities:
//   - Look up worker by key
//   - Return key validity state
// -----------------------------------------------------------------------------

using SparkFlow.Server.Domain.Interfaces;

namespace SparkFlow.Server.Application.Identity;

public sealed class WorkerIdentityService : IWorkerIdentityService
{
    private readonly IWorkerRepository _repository;

    public WorkerIdentityService(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Validate(string workerKey)
    {
        var worker = await _repository.GetByKeyAsync(workerKey);
        return worker is not null;
    }
}
