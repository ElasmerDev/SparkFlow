// -----------------------------------------------------------------------------
// File: RegisterWorkerRequest.cs
// Path: ./src/Server/SparkFlow.Server.Contracts/Worker/Requests/RegisterWorkerRequest.cs
// Summary:
//   Request contract used to register a worker with the server.
//
// Responsibilities:
//   - Carry installation identity data
//   - Carry machine fingerprint data
//   - Carry basic worker display metadata
//
// Notes:
//   - Required properties are enforced to make the API contract explicit.
//   - This contract should remain transport-focused and free of business logic.
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Contracts.Worker.Requests;

public sealed class RegisterWorkerRequest
{
    /// <summary>
    /// Unique installation identifier stored on the client machine.
    /// </summary>
    public required string InstallationId { get; set; }

    /// <summary>
    /// Stable machine fingerprint used to identify the device.
    /// </summary>
    public required string MachineFingerprint { get; set; }

    /// <summary>
    /// Protocol version used by the worker when communicating with the server.
    /// </summary>
    public int ProtocolVersion { get; set; }

    /// <summary>
    /// Human-readable worker name shown in dashboards and logs.
    /// </summary>
    public required string DisplayName { get; set; }

    /// <summary>
    /// Host machine name reported by the worker.
    /// </summary>
    public required string HostName { get; set; }
}