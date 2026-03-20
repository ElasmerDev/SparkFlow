// -----------------------------------------------------------------------------
// File: AppDbContext.cs
// Path: ./src/Server/SparkFlow.Server.Infrastructure/Persistence/AppDbContext.cs
// Summary:
//   Entity Framework Core database context for the server.
//
// Responsibilities:
//   - Expose worker persistence set
//   - Act as persistence root for server data
// -----------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using SparkFlow.Server.Domain.Workers;

namespace SparkFlow.Server.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Worker> Workers => Set<Worker>();
}
