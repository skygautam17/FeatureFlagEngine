using FeatureFlagEngine.Application.Interfaces;
using FeatureFlagEngine.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

public class EvaluateFeatureHandler
    : IRequestHandler<EvaluateFeatureQuery, bool>
{
    private readonly IAppDbContext _context;

    public EvaluateFeatureHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(
        EvaluateFeatureQuery request,
        CancellationToken cancellationToken)
    {
        // Load feature from database
        var feature = await _context.FeatureFlags
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Key == request.FeatureKey, cancellationToken);

        if (feature == null)
            return false;

        // Load overrides from database
        var overrides = await _context.FeatureOverrides
            .Where(o => o.FeatureFlagId == feature.Id)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        // Evaluate
        var result = FeatureEvaluationService.Evaluate(
            feature,
            overrides,
            request.UserId,
            request.GroupId,
            request.Region);

        return result;
    }
}
