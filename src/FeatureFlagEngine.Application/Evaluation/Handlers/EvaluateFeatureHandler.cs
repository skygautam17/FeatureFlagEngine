using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class EvaluateFeatureHandler
    : IRequestHandler<EvaluateFeatureQuery, bool>
{
    public Task<bool> Handle(
        EvaluateFeatureQuery request,
        CancellationToken cancellationToken)
    {
        var feature = FeatureStore.Features
            .FirstOrDefault(f => f.Key == request.FeatureKey);

        if (feature == null)
            return Task.FromResult(false);

        var overrides = OverrideStore.Overrides
            .Where(o => o.FeatureFlagId == feature.Id)
            .ToList();

        var result = FeatureEvaluationService.Evaluate(
            feature,
            overrides,
            request.UserId,
            request.GroupId,
            request.Region);

        return Task.FromResult(result);
    }
}
