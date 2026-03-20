// -----------------------------------------------------------------------------
// File: IWorkerIdentityService.cs
// Path: ./src/Server/SparkFlow.Server.Application/Identity/IWorkerIdentityService.cs
// Summary:
//   Defines worker identity validation behavior.
//
// Responsibilities:
//   - Validate worker keys
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Application.Identity;

public interface IWorkerIdentityService
{
    Task<bool> Validate(string workerKey);
}
