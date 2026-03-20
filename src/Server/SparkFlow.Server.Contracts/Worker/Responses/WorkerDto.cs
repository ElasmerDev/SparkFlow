// -----------------------------------------------------------------------------
// File: WorkerDto.cs
// Path: ./src/Server/SparkFlow.Server.Contracts/Worker/Responses/WorkerDto.cs
// Summary:
//   DTO used to display worker information.
//
// Responsibilities:
//   - Represent worker list item data
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Contracts.Worker.Responses;

public sealed class WorkerDto
{
    public Guid WorkerId { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public bool IsOnline { get; set; }

    public DateTime LastSeen { get; set; }
}
