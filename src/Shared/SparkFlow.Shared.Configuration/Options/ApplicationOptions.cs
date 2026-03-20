// -----------------------------------------------------------------------------
// File: ApplicationOptions.cs
// Path: src/Shared/SparkFlow.Shared.Configuration/Options/ApplicationOptions.cs
// Description:
//   Provides common application metadata configuration shared across hosts.
//   These values are useful for logging, diagnostics, and environment labeling.
// -----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace SparkFlow.Shared.Configuration.Options;

/// <summary>
/// Represents common application metadata options.
/// </summary>
public sealed class ApplicationOptions
{
    /// <summary>
    /// Configuration section name.
    /// </summary>
    public const string SectionName = "Application";

    /// <summary>
    /// Gets or sets the application name used in logs and diagnostics.
    /// </summary>
    [Required]
    public string ApplicationName { get; set; } = "SparkFlow";

    /// <summary>
    /// Gets or sets the logical environment name.
    /// </summary>
    [Required]
    public string EnvironmentName { get; set; } = "Development";

    /// <summary>
    /// Gets or sets an optional instance identifier for the current process or host.
    /// </summary>
    public string? InstanceName { get; set; }
}