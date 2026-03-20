// -----------------------------------------------------------------------------
// File: Worker.cs
// Path: ./src/Server/SparkFlow.Server.Domain/Workers/Worker.cs
// Summary:
//   Aggregate root representing a registered worker.
//
// Responsibilities:
//   - Store identity data
//   - Track registration and heartbeat state
//   - Evaluate online/offline status
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Domain.Workers;

public class Worker
{
    private Worker()
    {
    }

    public Worker(string installationId, string machineFingerprint, string protocolVersion)
    {
        if (string.IsNullOrWhiteSpace(installationId))
        {
            throw new ArgumentException("InstallationId is required.", nameof(installationId));
        }

        if (string.IsNullOrWhiteSpace(machineFingerprint))
        {
            throw new ArgumentException("MachineFingerprint is required.", nameof(machineFingerprint));
        }

        WorkerId = Guid.NewGuid();
        InstallationId = installationId;
        MachineFingerprint = machineFingerprint;
        ProtocolVersion = protocolVersion;
        WorkerKey = Guid.NewGuid().ToString("N");
        CreatedAt = DateTime.UtcNow;
        LastSeen = DateTime.UtcNow;
        IsOnline = true;
    }

    public Guid WorkerId { get; private set; }

    public string InstallationId { get; private set; } = string.Empty;

    public string MachineFingerprint { get; private set; } = string.Empty;

    public string ProtocolVersion { get; private set; } = string.Empty;

    public string WorkerKey { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    public DateTime LastSeen { get; private set; }

    public bool IsOnline { get; private set; }

    /// <summary>
    /// Marks the worker as alive and refreshes the last-seen timestamp.
    /// </summary>
    public void MarkAlive()
    {
        LastSeen = DateTime.UtcNow;
        IsOnline = true;
    }

    /// <summary>
    /// Evaluates whether the worker should be considered offline.
    /// </summary>
    public bool IsOffline(TimeSpan timeout)
    {
        return DateTime.UtcNow - LastSeen > timeout;
    }
}
