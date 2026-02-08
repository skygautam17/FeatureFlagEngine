using MediatR;
using FeatureFlagEngine.Domain.Entities;
using System;

public class CreateOverrideCommand : IRequest<FeatureOverride>
{
    public Guid FeatureFlagId { get; set; }
    public string UserId { get; set; }
    public string GroupId { get; set; }
    public bool Enabled { get; set; }
}