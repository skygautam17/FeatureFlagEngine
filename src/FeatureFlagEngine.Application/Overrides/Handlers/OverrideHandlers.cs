using MediatR;
using FeatureFlagEngine.Domain.Entities;
using FeatureFlagEngine.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

public class CreateOverrideHandler
    : IRequestHandler<CreateOverrideCommand, FeatureOverride>
{
    private readonly IAppDbContext _context;

    public CreateOverrideHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<FeatureOverride> Handle(
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

        _context.FeatureOverrides.Add(model);
        await _context.SaveChangesAsync(cancellationToken);

        return model;
    }
}

public class GetAllOverridesHandler
    : IRequestHandler<GetAllOverridesQuery, List<FeatureOverride>>
{
    private readonly IAppDbContext _context;

    public GetAllOverridesHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<FeatureOverride>> Handle(
        GetAllOverridesQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.FeatureOverrides
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}

public class DeleteOverrideHandler
    : IRequestHandler<DeleteOverrideCommand, bool>
{
    private readonly IAppDbContext _context;

    public DeleteOverrideHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(
        DeleteOverrideCommand request,
        CancellationToken cancellationToken)
    {
        var item = await _context.FeatureOverrides
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (item == null)
            return false;

        _context.FeatureOverrides.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
