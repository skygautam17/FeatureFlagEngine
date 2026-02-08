
using System;

namespace FeatureFlagEngine.Domain.Entities;

public class FeatureFlag
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Key { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Enabled { get; set; }
}
