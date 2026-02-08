using MediatR;
using FeatureFlagEngine.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

public static class OverrideStore
{
    public static List<FeatureOverride> Overrides = new();
}

public class CreateOverrideHandler
    : IRequestHandler<CreateOverrideCommand, FeatureOverride>
{
    public Task<FeatureOverride> Handle(
        CreateOverrideCommand request,
        CancellationToken cancellationToken)
    {
        var model = new FeatureOverride
        {
            FeatureFlagId = request.FeatureFlagId,
            UserId = request.UserId,
            GroupId = request.GroupId,
            Enabled = request.Enabled
        };

        OverrideStore.Overrides.Add(model);
        return Task.FromResult(model);
    }
}

public class GetAllOverridesHandler
    : IRequestHandler<GetAllOverridesQuery, List<FeatureOverride>>
{
    public Task<List<FeatureOverride>> Handle(
        GetAllOverridesQuery request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(OverrideStore.Overrides.ToList());
    }
}

public class DeleteOverrideHandler
    : IRequestHandler<DeleteOverrideCommand, bool>
{
    public Task<bool> Handle(
        DeleteOverrideCommand request,
        CancellationToken cancellationToken)
    {
        var item = OverrideStore.Overrides
            .FirstOrDefault(x => x.Id == request.Id);

        if (item == null)
            return Task.FromResult(false);

        OverrideStore.Overrides.Remove(item);
        return Task.FromResult(true);
    }
}
