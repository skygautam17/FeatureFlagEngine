using FeatureFlagEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagEngine.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<FeatureFlag> FeatureFlags { get; }
        DbSet<FeatureOverride> FeatureOverrides { get; }
        DbSet<AuditLog> AuditLogs { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
