using FeatureFlagEngine.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagEngine.Application.Audit
{
    public class GetAuditLogsQuery : IRequest<List<AuditLog>>
    {
    }
}
