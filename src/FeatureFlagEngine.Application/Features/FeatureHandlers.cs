using MediatR;
using FeatureFlagEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using FeatureFlagEngine.Application.Interfaces;

// CREATE FEATURE
public class CreateFeatureHandler : IRequestHandler<CreateFeatureCommand, FeatureFlag>
{
    private readonly IAppDbContext _context;

    public CreateFeatureHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<FeatureFlag> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = new FeatureFlag
        {
            Key = request.Key,
            Description = request.Description,
            Enabled = request.Enabled
        };

        _context.FeatureFlags.Add(feature);
        await _context.SaveChangesAsync(cancellationToken);

        return feature;
    }
}

// GET ALL FEATURES
public class GetAllFeaturesHandler : IRequestHandler<GetAllFeaturesQuery, List<FeatureFlag>>
{
    private readonly IAppDbContext _context;

    public GetAllFeaturesHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<FeatureFlag>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
    {
        return await _context.FeatureFlags.ToListAsync(cancellationToken);
    }
}

// DELETE FEATURE
public class DeleteFeatureHandler : IRequestHandler<DeleteFeatureCommand, bool>
{
    private readonly IAppDbContext _context;

    public DeleteFeatureHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = await _context.FeatureFlags
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (feature == null)
            return false;

        _context.FeatureFlags.Remove(feature);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}

public class UpdateFeatureHandler : IRequestHandler<UpdateFeatureCommand, bool>
{
    private readonly IAppDbContext _context;

    public UpdateFeatureHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = await _context.FeatureFlags
            .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

        if (feature == null)
            return false;

        feature.Key = request.Key;
        feature.Description = request.Description;
        feature.Enabled = request.Enabled;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
