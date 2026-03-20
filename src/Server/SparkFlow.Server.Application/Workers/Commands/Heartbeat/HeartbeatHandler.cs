// -----------------------------------------------------------------------------
// File: HeartbeatHandler.cs
// Path: ./src/Server/SparkFlow.Server.Application/Workers/Commands/Heartbeat/HeartbeatHandler.cs
// Summary:
//   Handles worker heartbeat updates.
//
// Responsibilities:
//   - Find worker by key
//   - Update worker liveness timestamp
//   - Persist changes
// -----------------------------------------------------------------------------

using MediatR;
using SparkFlow.Server.Domain.Interfaces;

namespace SparkFlow.Server.Application.Workers.Commands.Heartbeat;

public sealed class HeartbeatHandler : IRequestHandler<HeartbeatCommand, bool>
{
    private readonly IWorkerRepository _repository;

    public HeartbeatHandler(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(HeartbeatCommand request, CancellationToken cancellationToken)
    {
        var worker = await _repository.GetByKeyAsync(request.WorkerKey);

        if (worker is null)
        {
            return false;
        }

        worker.MarkAlive();

        await _repository.SaveChangesAsync();

        return true;
    }
}
