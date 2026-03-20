// -----------------------------------------------------------------------------
// File: RegisterWorkerResponse.cs
// Path: ./src/Server/SparkFlow.Server.Contracts/Worker/Responses/RegisterWorkerResponse.cs
// Summary:
//   Response contract returned after worker registration.
//
// Responsibilities:
//   - Return worker identifier
//   - Return worker secret key
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Contracts.Worker.Responses;

public sealed class RegisterWorkerResponse
{
    public Guid WorkerId { get; set; }

    public string WorkerKey { get; set; } = string.Empty;
}
