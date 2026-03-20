// -----------------------------------------------------------------------------
// File: ServerConnectionOptions.cs
// Path: src/Shared/SparkFlow.Shared.Configuration/Options/ServerConnectionOptions.cs
// Description:
//   Represents shared connectivity settings used by Agent, Worker, or Admin
//   clients when communicating with the central server.
// -----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace SparkFlow.Shared.Configuration.Options;

/// <summary>
/// Represents the central server connectivity configuration.
/// </summary>
public sealed class ServerConnectionOptions
{
    /// <summary>
    /// Configuration section name.
    /// </summary>
    public const string SectionName = "Server";

    /// <summary>
    /// Gets or sets the base URL for the central SparkFlow server.
    /// </summary>
    [Required]
    public string BaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the default request timeout in seconds.
    /// </summary>
    [Range(1, 600)]
    public int RequestTimeoutSeconds { get; set; } = 30;

    /// <summary>
    /// Gets or sets an optional API key or shared secret identifier.
    /// This field can remain empty until security hardening is implemented.
    /// </summary>
    public string? ApiKey { get; set; }
}