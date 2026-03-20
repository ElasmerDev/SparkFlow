// -----------------------------------------------------------------------------
// File: HostBuilderExtensions.cs
// Path: src/Shared/SparkFlow.Shared.Logging/Extensions/HostBuilderExtensions.cs
// Description:
//   Adds a shared Serilog host configuration for all SparkFlow hosts.
//   This extension is intended for Server, Agent, Admin, and any other host
//   using Microsoft.Extensions.Hosting.
// -----------------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.File;
using SparkFlow.Shared.Configuration.Options;
using SparkFlow.Shared.Logging.Constants;

namespace SparkFlow.Shared.Logging.Extensions;

/// <summary>
/// Provides shared Serilog setup helpers for host builders.
/// </summary>
public static class HostBuilderExtensions
{
    /// <summary>
    /// Applies the shared SparkFlow Serilog configuration to the host builder.
    /// </summary>
    /// <param name="hostBuilder">
    /// The target host builder.
    /// </param>
    /// <param name="applicationName">
    /// The application name to appear in structured logs.
    /// </param>
    public static IHostBuilder UseSparkFlowSerilog(
        this IHostBuilder hostBuilder,
        string applicationName)
    {
        ArgumentNullException.ThrowIfNull(hostBuilder);

        return hostBuilder.UseSerilog((context, _, loggerConfiguration) =>
        {
            var loggingOptions = BindLoggingOptions(context.Configuration);
            var applicationOptions = BindApplicationOptions(context.Configuration, applicationName);

            ConfigureSharedLogger(
                loggerConfiguration,
                loggingOptions,
                applicationOptions.ApplicationName,
                applicationOptions.EnvironmentName,
                applicationOptions.InstanceName);
        });
    }

    /// <summary>
    /// Creates a lightweight bootstrap logger that can be used before the host is built.
    /// </summary>
    /// <param name="applicationName">
    /// The application name to appear in startup logs.
    /// </param>
    public static ILogger CreateBootstrapLogger(string applicationName)
    {
        var effectiveApplicationName = string.IsNullOrWhiteSpace(applicationName)
            ? "SparkFlow"
            : applicationName;

        return new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .Enrich.WithProperty(LogPropertyNames.Application, effectiveApplicationName)
            .Enrich.WithProperty(LogPropertyNames.Environment, "Bootstrap")
            .Enrich.WithProperty(LogPropertyNames.MachineName, Environment.MachineName)
            .WriteTo.Console()
            .WriteTo.Debug()
            .CreateLogger();
    }

    private static LoggingOptions BindLoggingOptions(IConfiguration configuration)
    {
        var options = new LoggingOptions();
        configuration.GetSection(LoggingOptions.SectionName).Bind(options);
        return options;
    }

    private static ApplicationOptions BindApplicationOptions(
        IConfiguration configuration,
        string fallbackApplicationName)
    {
        var options = new ApplicationOptions();
        configuration.GetSection(ApplicationOptions.SectionName).Bind(options);

        if (string.IsNullOrWhiteSpace(options.ApplicationName))
        {
            options.ApplicationName = string.IsNullOrWhiteSpace(fallbackApplicationName)
                ? "SparkFlow"
                : fallbackApplicationName;
        }

        if (string.IsNullOrWhiteSpace(options.EnvironmentName))
        {
            options.EnvironmentName = "Development";
        }

        return options;
    }

    private static void ConfigureSharedLogger(
        LoggerConfiguration loggerConfiguration,
        LoggingOptions loggingOptions,
        string applicationName,
        string environmentName,
        string? instanceName)
    {
        var level = ParseLogLevel(loggingOptions.MinimumLevel);
        var rollingInterval = ParseRollingInterval(loggingOptions.RollingInterval);
        var logDirectory = ResolveLogDirectory(loggingOptions.LogDirectory);
        var fileName = $"{SanitizeFileName(applicationName)}-.json";
        var filePath = Path.Combine(logDirectory, fileName);

        Directory.CreateDirectory(logDirectory);

        loggerConfiguration
            .MinimumLevel.Is(level)
            .Enrich.FromLogContext()
            .Enrich.WithProperty(LogPropertyNames.Application, applicationName)
            .Enrich.WithProperty(LogPropertyNames.Environment, environmentName)
            .Enrich.WithProperty(LogPropertyNames.Instance, instanceName ?? string.Empty)
            .Enrich.WithProperty(LogPropertyNames.MachineName, Environment.MachineName);

        if (loggingOptions.WriteToConsole)
        {
            loggerConfiguration.WriteTo.Console();
        }

        if (loggingOptions.WriteToDebug)
        {
            loggerConfiguration.WriteTo.Debug();
        }

        if (loggingOptions.WriteToFile)
        {
            loggerConfiguration.WriteTo.File(
                formatter: new CompactJsonFormatter(),
                path: filePath,
                rollingInterval: rollingInterval,
                retainedFileCountLimit: loggingOptions.RetainedFileCountLimit,
                shared: true);
        }
    }

    private static LogEventLevel ParseLogLevel(string? value)
    {
        if (Enum.TryParse<LogEventLevel>(value, ignoreCase: true, out var level))
        {
            return level;
        }

        return LogEventLevel.Information;
    }

    private static RollingInterval ParseRollingInterval(string? value)
    {
        if (Enum.TryParse<RollingInterval>(value, ignoreCase: true, out var rollingInterval))
        {
            return rollingInterval;
        }

        return RollingInterval.Day;
    }

    private static string ResolveLogDirectory(string? configuredPath)
    {
        if (string.IsNullOrWhiteSpace(configuredPath))
        {
            return Path.Combine(AppContext.BaseDirectory, "logs");
        }

        if (Path.IsPathRooted(configuredPath))
        {
            return configuredPath;
        }

        return Path.Combine(AppContext.BaseDirectory, configuredPath);
    }

    private static string SanitizeFileName(string fileName)
    {
        var invalid = Path.GetInvalidFileNameChars();
        var sanitized = fileName;

        foreach (var character in invalid)
        {
            sanitized = sanitized.Replace(character, '-');
        }

        return sanitized;
    }
}