// -----------------------------------------------------------------------------
// File: DependencyInjection.cs
// Path: ./src/Server/SparkFlow.Server.Api/Extensions/DependencyInjection.cs
// Summary:
//   Registers application and infrastructure services for the server API.
//
// Responsibilities:
//   - Register MediatR handlers
//   - Register application services
//   - Register database and repository services
// -----------------------------------------------------------------------------

using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkFlow.Server.Application;
using SparkFlow.Server.Application.Identity;
using SparkFlow.Server.Application.Workers.Services;
using SparkFlow.Server.Domain.Interfaces;
using SparkFlow.Server.Infrastructure.Persistence;
using SparkFlow.Server.Infrastructure.Repositories;

namespace SparkFlow.Server.Api.Extensions;

public static class DependencyInjection
{
    /// <summary>
    /// Registers application-layer services.
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(AssemblyReference).Assembly);
        services.AddScoped<IWorkerIdentityService, WorkerIdentityService>();
        services.AddScoped<WorkerAssignmentEngine>();

        return services;
    }

    /// <summary>
    /// Registers infrastructure-layer services.
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Temporary in-memory storage for early MVP development.
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("SparkFlowDb"));

        services.AddScoped<IWorkerRepository, WorkerRepository>();

        return services;
    }
}
