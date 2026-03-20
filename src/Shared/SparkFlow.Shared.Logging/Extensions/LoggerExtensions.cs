// -----------------------------------------------------------------------------
// File: LoggerExtensions.cs
// Path: src/Shared/SparkFlow.Shared.Logging/Extensions/LoggerExtensions.cs
// Description:
//   Provides structured logging scopes for common SparkFlow context values.
//   These scopes work with Microsoft.Extensions.Logging and improve correlation.
// -----------------------------------------------------------------------------

using Microsoft.Extensions.Logging;
using SparkFlow.Shared.Logging.Constants;

namespace SparkFlow.Shared.Logging.Extensions;

/// <summary>
/// Provides helper methods for attaching common scope values to logs.
/// </summary>
public static class LoggerExtensions
{
    /// <summary>
    /// Begins a logging scope with a correlation identifier.
    /// </summary>
    public static IDisposable BeginCorrelationScope(this ILogger logger, string correlationId)
    {
        ArgumentNullException.ThrowIfNull(logger);

        return logger.BeginScope(new Dictionary<string, object?>
        {
            [LogPropertyNames.CorrelationId] = correlationId
        });
    }

    /// <summary>
    /// Begins a logging scope with worker identity values.
    /// </summary>
    public static IDisposable BeginWorkerScope(
        this ILogger logger,
        string? workerId,
        string? installationId)
    {
        ArgumentNullException.ThrowIfNull(logger);

        return logger.BeginScope(new Dictionary<string, object?>
        {
            [LogPropertyNames.WorkerId] = workerId,
            [LogPropertyNames.InstallationId] = installationId
        });
    }
}