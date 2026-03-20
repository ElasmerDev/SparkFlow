// -----------------------------------------------------------------------------
// File: ServiceCollectionExtensions.cs
// Path: src/Shared/SparkFlow.Shared.Configuration/Extensions/ServiceCollectionExtensions.cs
// Description:
//   Registers Shared Foundation configuration objects using the Microsoft
//   Options pattern with startup validation enabled.
// -----------------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SparkFlow.Shared.Configuration.Options;
using SparkFlow.Shared.Core.Time;

namespace SparkFlow.Shared.Configuration.Extensions;

/// <summary>
/// Provides service registration helpers for shared configuration components.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the core shared configuration objects and the system clock.
    /// </summary>
    /// <param name="services">
    /// The target service collection.
    /// </param>
    /// <param name="configuration">
    /// The application configuration root.
    /// </param>
    public static IServiceCollection AddSparkFlowSharedFoundation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddSingleton<IClock, SystemClock>();

        services.AddOptions<ApplicationOptions>()
            .Bind(configuration.GetSection(ApplicationOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddOptions<ServerConnectionOptions>()
            .Bind(configuration.GetSection(ServerConnectionOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddOptions<LocalApiOptions>()
            .Bind(configuration.GetSection(LocalApiOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddOptions<LoggingOptions>()
            .Bind(configuration.GetSection(LoggingOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}