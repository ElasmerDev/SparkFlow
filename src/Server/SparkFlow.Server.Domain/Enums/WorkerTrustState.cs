// -----------------------------------------------------------------------------
// File: WorkerTrustState.cs
// Path: ./src/Server/SparkFlow.Server.Domain/Enums/WorkerTrustState.cs
// Summary:
//   Trust state values for a worker.
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Domain.Enums;

public enum WorkerTrustState
{
    Unverified,
    Trusted,
    SuspiciousClone,
    ProtocolMismatch,
    Revoked
}
