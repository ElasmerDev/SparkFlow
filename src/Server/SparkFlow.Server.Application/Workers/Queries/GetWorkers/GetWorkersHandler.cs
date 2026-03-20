// -----------------------------------------------------------------------------
// File: GetWorkersHandler.cs
// Path: ./src/Server/SparkFlow.Server.Application/Workers/Queries/GetWorkers/GetWorkersHandler.cs
// Summary:
//   Returns worker list data for API consumers.
//
// Responsibilities:
//   - Query workers from repository
//   - Map domain entities to DTOs
//   - Compute basic online state
// -----------------------------------------------------------------------------

using MediatR;
using SparkFlow.Server.Contracts.Worker.Responses;
using SparkFlow.Server.Domain.Interfaces;

namespace SparkFlow.Server.Application.Workers.Queries.GetWorkers;

public sealed class GetWorkersHandler : IRequestHandler<GetWorkersQuery, List<WorkerDto>>
{
    private readonly IWorkerRepository _repository;

    public GetWorkersHandler(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WorkerDto>> Handle(GetWorkersQuery request, CancellationToken cancellationToken)
    {
        var workers = await _repository.GetAllAsync();

        return workers
            .Select(worker => new WorkerDto
            {
                WorkerId = worker.WorkerId,
                DisplayName = worker.InstallationId,
                LastSeen = worker.LastSeen,
                IsOnline = !worker.IsOffline(TimeSpan.FromSeconds(30))
            })
            .ToList();
    }
}
