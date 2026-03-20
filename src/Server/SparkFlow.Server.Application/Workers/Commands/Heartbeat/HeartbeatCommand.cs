// -----------------------------------------------------------------------------
// File: HeartbeatCommand.cs
// Path: ./src/Server/SparkFlow.Server.Application/Workers/Commands/Heartbeat/HeartbeatCommand.cs
// Summary:
//   Represents a worker heartbeat command.
//
// Responsibilities:
//   - Carry worker key data to the handler
// -----------------------------------------------------------------------------

using MediatR;

namespace SparkFlow.Server.Application.Workers.Commands.Heartbeat;

public sealed class HeartbeatCommand : IRequest<bool>
{
    public HeartbeatCommand(string workerKey)
    {
        WorkerKey = workerKey;
    }

    public string WorkerKey { get; }
}
