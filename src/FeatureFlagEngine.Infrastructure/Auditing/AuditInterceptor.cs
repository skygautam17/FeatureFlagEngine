using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using FeatureFlagEngine.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class AuditInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;

        if (context == null)
            return await base.SavingChangesAsync(eventData, result, cancellationToken);

        var auditEntries = context.ChangeTracker.Entries()
            .Where(e =>
                e.Entity is not AuditLog &&
                (e.State == EntityState.Added ||
                 e.State == EntityState.Modified ||
                 e.State == EntityState.Deleted))
            .ToList();

        foreach (var entry in auditEntries)
        {
            var audit = new AuditLog
            {
                EntityName = entry.Entity.GetType().Name,
                Action = entry.State.ToString(),
                CreatedAt = DateTime.UtcNow,
                Changes = entry.Properties
                    .Where(p => p.IsModified || entry.State == EntityState.Added)
                    .Select(p => $"{p.Metadata.Name}: {p.CurrentValue}")
                    .Aggregate("", (a, b) => a + b + "; ")
            };

            context.Set<AuditLog>().Add(audit);
        }

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
