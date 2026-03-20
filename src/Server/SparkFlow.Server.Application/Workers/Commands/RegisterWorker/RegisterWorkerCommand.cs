// -----------------------------------------------------------------------------
// File: RegisterWorkerCommand.cs
// Path: ./src/Server/SparkFlow.Server.Application/Workers/Commands/RegisterWorker/RegisterWorkerCommand.cs
// Summary:
//   Represents a worker registration command.
//
// Responsibilities:
//   - Carry worker registration data to the handler
// -----------------------------------------------------------------------------

using MediatR;
using SparkFlow.Server.Contracts.Worker.Responses;

namespace SparkFlow.Server.Application.Workers.Commands.RegisterWorker;

public sealed class RegisterWorkerCommand : IRequest<RegisterWorkerResponse>
{
    public RegisterWorkerCommand(
        string installationId,
        string machineFingerprint,
        string protocolVersion,
        string displayName,
        string hostName)
    {
        InstallationId = installationId;
        MachineFingerprint = machineFingerprint;
        ProtocolVersion = protocolVersion;
        DisplayName = displayName;
        HostName = hostName;
    }

    public string InstallationId { get; }
    public string MachineFingerprint { get; }
    public string ProtocolVersion { get; }
    public string DisplayName { get; }
    public string HostName { get; }
}
