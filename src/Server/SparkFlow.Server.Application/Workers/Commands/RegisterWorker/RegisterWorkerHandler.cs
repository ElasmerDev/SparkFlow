// -----------------------------------------------------------------------------
// File: RegisterWorkerHandler.cs
// Path: ./src/Server/SparkFlow.Server.Application/Workers/Commands/RegisterWorker/RegisterWorkerHandler.cs
// Summary:
//   Handles worker registration requests.
//
// Responsibilities:
//   - Create a worker aggregate
//   - Persist the worker
//   - Return registration response data
// -----------------------------------------------------------------------------

using MediatR;
using SparkFlow.Server.Contracts.Worker.Responses;
using SparkFlow.Server.Domain.Interfaces;
using SparkFlow.Server.Domain.Workers;

namespace SparkFlow.Server.Application.Workers.Commands.RegisterWorker;

public sealed class RegisterWorkerHandler : IRequestHandler<RegisterWorkerCommand, RegisterWorkerResponse>
{
    private readonly IWorkerRepository _repository;

    public RegisterWorkerHandler(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<RegisterWorkerResponse> Handle(RegisterWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = new Worker(
            request.InstallationId,
            request.MachineFingerprint,
            request.ProtocolVersion);

        await _repository.AddAsync(worker);
        await _repository.SaveChangesAsync();

        return new RegisterWorkerResponse
        {
            WorkerId = worker.WorkerId,
            WorkerKey = worker.WorkerKey
        };
    }
}
