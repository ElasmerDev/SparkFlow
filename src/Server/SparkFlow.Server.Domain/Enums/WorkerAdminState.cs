// -----------------------------------------------------------------------------
// File: WorkerAdminState.cs
// Path: ./src/Server/SparkFlow.Server.Domain/Enums/WorkerAdminState.cs
// Summary:
//   Administrative lifecycle states for a worker.
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Domain.Enums;

public enum WorkerAdminState
{
    PendingApproval,
    Active,
    Disabled,
    Revoked
}
