// -----------------------------------------------------------------------------
// File: LoggingOptions.cs
// Path: src/Shared/SparkFlow.Shared.Configuration/Options/LoggingOptions.cs
// Description:
//   Represents the shared logging configuration for all SparkFlow hosts.
//   These settings are consumed by the Serilog setup helpers in Shared.Logging.
// -----------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace SparkFlow.Shared.Configuration.Options;

/// <summary>
/// Represents shared logging settings.
/// </summary>
public sealed class LoggingOptions
{
    /// <summary>
    /// Configuration section name.
    /// </summary>
    public const string SectionName = "Logging";

    /// <summary>
    /// Gets or sets the minimum log level as text.
    /// Valid values include Verbose, Debug, Information, Warning, Error, and Fatal.
    /// </summary>
    [Required]
    public string MinimumLevel { get; set; } = "Information";

    /// <summary>
    /// Gets or sets the relative or absolute log directory path.
    /// </summary>
    [Required]
    public string LogDirectory { get; set; } = "logs";

    /// <summary>
    /// Gets or sets the rolling interval value as text.
    /// Valid values include Infinite, Year, Month, Day, Hour, and Minute.
    /// </summary>
    [Required]
    public string RollingInterval { get; set; } = "Day";

    /// <summary>
    /// Gets or sets the maximum number of retained log files.
    /// </summary>
    [Range(1, 365)]
    public int RetainedFileCountLimit { get; set; } = 30;

    /// <summary>
    /// Gets or sets a value indicating whether console logging is enabled.
    /// </summary>
    public bool WriteToConsole { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether debug sink logging is enabled.
    /// </summary>
    public bool WriteToDebug { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether file sink logging is enabled.
    /// </summary>
    public bool WriteToFile { get; set; } = true;
}