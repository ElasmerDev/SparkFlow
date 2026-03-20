// -----------------------------------------------------------------------------
// File: HeartbeatRequest.cs
// Path: ./src/Server/SparkFlow.Server.Contracts/Worker/Requests/HeartbeatRequest.cs
// Summary:
//   Request contract for worker heartbeat.
//
// Responsibilities:
//   - Carry worker key data
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Contracts.Worker.Requests;

public sealed class HeartbeatRequest
{
    public required string WorkerKey { get; set; }
}
