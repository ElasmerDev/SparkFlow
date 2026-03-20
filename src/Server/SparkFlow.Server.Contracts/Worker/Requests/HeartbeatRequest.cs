// -----------------------------------------------------------------------------
// File: HeartbeatRequest.cs
// Path: ./src/Server/SparkFlow.Server.Contracts/Worker/Requests/HeartbeatRequest.cs
// Summary:
//   Request contract used to send worker heartbeat data to the server.
//
// Responsibilities:
//   - Carry the worker key required for worker identity validation
//
// Notes:
//   - This is intentionally minimal for the first server MVP.
//   - Additional heartbeat metrics can be added later without changing the endpoint purpose.
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Contracts.Worker.Requests;

public sealed class HeartbeatRequest
{
    /// <summary>
    /// Secret worker key assigned during registration and used for worker authentication.
    /// </summary>
    public required string WorkerKey { get; set; }
}