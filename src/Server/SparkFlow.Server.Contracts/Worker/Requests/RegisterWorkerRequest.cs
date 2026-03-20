// -----------------------------------------------------------------------------
// File: RegisterWorkerRequest.cs
// Path: ./src/Server/SparkFlow.Server.Contracts/Worker/Requests/RegisterWorkerRequest.cs
// Summary:
//   Request contract for worker registration.
//
// Responsibilities:
//   - Carry installation and machine identity data
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Contracts.Worker.Requests;

public sealed class RegisterWorkerRequest
{
    public string InstallationId { get; set; } = string.Empty;

    public string MachineFingerprint { get; set; } = string.Empty;

    public int ProtocolVersion { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public string HostName { get; set; } = string.Empty;
}
