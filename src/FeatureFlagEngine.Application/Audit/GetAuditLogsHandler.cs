using FeatureFlagEngine.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace FeatureFlagEngine.Application.Audit
{
    public static class AuditStore
    {
        public static List<AuditLog> Logs = new();
    }
    public class GetAuditLogsHandler
        : IRequestHandler<GetAuditLogsQuery, List<AuditLog>>
    {
        public Task<List<AuditLog>> Handle(
            GetAuditLogsQuery request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(AuditStore.Logs.ToList());
        }
    }
}
