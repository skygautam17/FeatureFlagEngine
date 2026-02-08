
using Microsoft.EntityFrameworkCore;
using FeatureFlagEngine.Domain.Entities;
using FeatureFlagEngine.Application.Interfaces;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<FeatureFlag> FeatureFlags => Set<FeatureFlag>();
    public DbSet<FeatureOverride> FeatureOverrides => Set<FeatureOverride>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public void ApplyMigrations()
    {
        if (Database.IsRelational())   // Runs only for SQL Server, not InMemory
        {
            Database.Migrate();
        }
    }
}
