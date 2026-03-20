// -----------------------------------------------------------------------------
// File: LogPropertyNames.cs
// Path: src/Shared/SparkFlow.Shared.Logging/Constants/LogPropertyNames.cs
// Description:
//   Defines the standard structured logging property names used across SparkFlow.
//   Keeping these names centralized helps preserve consistency in logs and search.
// -----------------------------------------------------------------------------

namespace SparkFlow.Shared.Logging.Constants;

/// <summary>
/// Contains well-known structured logging property names.
/// </summary>
public static class LogPropertyNames
{
    public const string Application = "Application";
    public const string Environment = "Environment";
    public const string Instance = "Instance";
    public const string CorrelationId = "CorrelationId";
    public const string WorkerId = "WorkerId";
    public const string InstallationId = "InstallationId";
    public const string MachineName = "MachineName";
}