
using MediatR;
using FeatureFlagEngine.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

public class UpdateFeatureHandler : IRequestHandler<UpdateFeatureCommand, bool>
{
    public Task<bool> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = FeatureStore.Features.FirstOrDefault(f => f.Id == request.Id);
        if (feature == null) return Task.FromResult(false);

        feature.Key = request.Key;
        feature.Description = request.Description;
        feature.Enabled = request.Enabled;

        return Task.FromResult(true);
    }
}
