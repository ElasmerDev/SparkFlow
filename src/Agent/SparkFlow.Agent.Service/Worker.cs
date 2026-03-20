// -----------------------------------------------------------------------------
// File: Worker.cs
// Path: ./src/Server/SparkFlow.Server.Domain/Workers/Worker.cs
// Summary:
//   Aggregate root representing a registered worker.
//
// Responsibilities:
//   - Store worker identity data
//   - Store display and host metadata
//   - Track heartbeat activity
//   - Evaluate online/offline state
//
// Notes:
//   - This is the core worker entity used by the server domain.
//   - Domain rules related to worker state should live here.
// -----------------------------------------------------------------------------

namespace SparkFlow.Server.Domain.Workers;

public class Worker
{
    private Worker()
    {
    }

    public Worker(
        string installationId,
        string machineFingerprint,
        string protocolVersion,
        string displayName,
        string hostName)
    {
        if (string.IsNullOrWhiteSpace(installationId))
        {
            throw new ArgumentException("InstallationId is required.", nameof(installationId));
        }

        if (string.IsNullOrWhiteSpace(machineFingerprint))
        {
            throw new ArgumentException("MachineFingerprint is required.", nameof(machineFingerprint));
        }

        if (string.IsNullOrWhiteSpace(protocolVersion))
        {
            throw new ArgumentException("ProtocolVersion is required.", nameof(protocolVersion));
        }

        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new ArgumentException("DisplayName is required.", nameof(displayName));
        }

        if (string.IsNullOrWhiteSpace(hostName))
        {
            throw new ArgumentException("HostName is required.", nameof(hostName));
        }

        WorkerId = Guid.NewGuid();
        InstallationId = installationId;
        MachineFingerprint = machineFingerprint;
        ProtocolVersion = protocolVersion;
        DisplayName = displayName;
        HostName = hostName;
        WorkerKey = Guid.NewGuid().ToString("N");
        CreatedAt = DateTime.UtcNow;
        LastSeen = DateTime.UtcNow;
        IsOnline = true;
    }

    public Guid WorkerId { get; private set; }

    public string InstallationId { get; private set; } = string.Empty;

    public string MachineFingerprint { get; private set; } = string.Empty;

    public string ProtocolVersion { get; private set; } = string.Empty;

    public string DisplayName { get; private set; } = string.Empty;

    public string HostName { get; private set; } = string.Empty;

    public string WorkerKey { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    public DateTime LastSeen { get; private set; }

    public bool IsOnline { get; private set; }

    /// <summary>
    /// Marks the worker as alive and refreshes its last-seen timestamp.
    /// </summary>
    public void MarkAlive()
    {
        LastSeen = DateTime.UtcNow;
        IsOnline = true;
    }

    /// <summary>
    /// Returns true when the worker exceeded the allowed heartbeat timeout.
    /// </summary>
    public bool IsOffline(TimeSpan timeout)
    {
        return DateTime.UtcNow - LastSeen > timeout;
    }
}