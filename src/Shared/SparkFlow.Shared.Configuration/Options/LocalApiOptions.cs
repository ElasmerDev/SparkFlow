// -----------------------------------------------------------------------------
// File: LocalApiOptions.cs
// Path: src/Shared/SparkFlow.Shared.Configuration/Options/LocalApiOptions.cs
// Description:
//   Represents loopback/local communication settings used between local
//   SparkFlow components such as Worker and Agent.
// -----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace SparkFlow.Shared.Configuration.Options;

/// <summary>
/// Represents localhost API configuration shared by local components.
/// </summary>
public sealed class LocalApiOptions
{
    /// <summary>
    /// Configuration section name.
    /// </summary>
    public const string SectionName = "LocalApi";

    /// <summary>
    /// Gets or sets the host name used for local communication.
    /// </summary>
    [Required]
    public string Host { get; set; } = "127.0.0.1";

    /// <summary>
    /// Gets or sets the port used for local communication.
    /// </summary>
    [Range(1, 65535)]
    public int Port { get; set; } = 5271;

    /// <summary>
    /// Gets or sets a value indicating whether HTTPS should be used.
    /// </summary>
    public bool UseHttps { get; set; }

    /// <summary>
    /// Gets or sets the default request timeout in seconds.
    /// </summary>
    [Range(1, 600)]
    public int RequestTimeoutSeconds { get; set; } = 15;

    /// <summary>
    /// Builds the local base address from the configured host, port, and protocol.
    /// </summary>
    public string GetBaseAddress()
    {
        var scheme = UseHttps ? "https" : "http";
        return $"{scheme}://{Host}:{Port}";
    }
}