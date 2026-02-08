
using MediatR;
using FeatureFlagEngine.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

public static class FeatureStore
{
    public static List<FeatureFlag> Features = new();
}

public class CreateFeatureHandler : IRequestHandler<CreateFeatureCommand, FeatureFlag>
{
    public Task<FeatureFlag> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        var f = new FeatureFlag{ Key=request.Key, Description=request.Description, Enabled=request.Enabled };
        FeatureStore.Features.Add(f);
        return Task.FromResult(f);
    }
}

public class GetAllFeaturesHandler : IRequestHandler<GetAllFeaturesQuery,List<FeatureFlag>>
{
    public Task<List<FeatureFlag>> Handle(GetAllFeaturesQuery request,CancellationToken cancellationToken)
        => Task.FromResult(FeatureStore.Features);
}

public class DeleteFeatureHandler : IRequestHandler<DeleteFeatureCommand,bool>
{
    public Task<bool> Handle(DeleteFeatureCommand request,CancellationToken cancellationToken)
    {
        var f = FeatureStore.Features.FirstOrDefault(x=>x.Id==request.Id);
        if(f==null) return Task.FromResult(false);
        FeatureStore.Features.Remove(f);
        return Task.FromResult(true);
    }
}
