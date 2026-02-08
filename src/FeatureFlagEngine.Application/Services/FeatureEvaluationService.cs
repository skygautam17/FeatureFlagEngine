
using FeatureFlagEngine.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

public static class FeatureEvaluationService
{
    // NOTE: Order of precedence
    // User > Group > Region > Global

    public static bool Evaluate(
        FeatureFlag feature,
        IEnumerable<FeatureOverride> overrides,
        string? userId,
        string? groupId,
        string? region)
    {
        var userOverride = overrides.FirstOrDefault(o => o.UserId == userId);
        if (userOverride != null) return userOverride.Enabled;

        var groupOverride = overrides.FirstOrDefault(o => o.GroupId == groupId);
        if (groupOverride != null) return groupOverride.Enabled;

        var regionOverride = overrides.FirstOrDefault(o => o.Region == region);
        if (regionOverride != null) return regionOverride.Enabled;

        return feature.Enabled;
    }
}
