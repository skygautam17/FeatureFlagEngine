using FeatureFlagEngine.Domain.Entities;
using FeatureFlagEngine.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FeatureFlagEngine.Application.Audit
{
    public class GetAuditLogsHandler
        : IRequestHandler<GetAuditLogsQuery, List<AuditLog>>
    {
        private readonly IAppDbContext _context;

        public GetAuditLogsHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuditLog>> Handle(
            GetAuditLogsQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.AuditLogs
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}
