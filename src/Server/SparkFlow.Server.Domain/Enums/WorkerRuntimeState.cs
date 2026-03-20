// -----------------------------------------------------------------------------
// File: WorkerRuntimeState.cs
// Path: ./src/Server/SparkFlow.Server.Domain/Enums/WorkerRuntimeState.cs
// Summary:
//   Runtime state values for a worker.
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Domain.Enums;

public enum WorkerRuntimeState
{
    Offline,
    Online,
    Idle,
    Busy,
    Unhealthy
}
