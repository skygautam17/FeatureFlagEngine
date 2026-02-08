
using Microsoft.EntityFrameworkCore;
using FeatureFlagEngine.Domain.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<FeatureFlag> FeatureFlags => Set<FeatureFlag>();
    public DbSet<FeatureOverride> FeatureOverrides => Set<FeatureOverride>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
}
