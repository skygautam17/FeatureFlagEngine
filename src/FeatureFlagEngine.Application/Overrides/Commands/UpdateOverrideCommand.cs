using FeatureFlagEngine.Domain.Entities;
using MediatR;

public class UpdateOverrideCommand : IRequest<FeatureOverride>
{
    public Guid Id { get; set; }
    public string? UserId { get; set; }
    public string? GroupId { get; set; }
    public bool Enabled { get; set; }
}
