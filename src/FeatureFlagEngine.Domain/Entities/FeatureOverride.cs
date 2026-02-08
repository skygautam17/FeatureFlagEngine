
using System;

namespace FeatureFlagEngine.Domain.Entities;

public class FeatureOverride
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid FeatureFlagId { get; set; }

    public string? UserId { get; set; }
    public string? GroupId { get; set; }
    public string? Region { get; set; }   // NEW: Region override support

    public bool Enabled { get; set; }
}
