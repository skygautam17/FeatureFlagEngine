
using Xunit;
using FeatureFlagEngine.Domain.Entities;

public class FeatureEvaluationServiceTests
{
    [Fact]
    public void Should_Return_Global_When_No_Overrides()
    {
        var feature = new FeatureFlag { Enabled = true };
        var overrides = new List<FeatureOverride>();

        var result = FeatureEvaluationService.Evaluate(feature, overrides, null, null, null);

        Assert.True(result);
    }

    [Fact]
    public void Should_Return_UserOverride_Over_Group_And_Global()
    {
        var feature = new FeatureFlag { Enabled = false };

        var overrides = new List<FeatureOverride>
        {
            new FeatureOverride { GroupId = "admin", Enabled = false },
            new FeatureOverride { UserId = "user1", Enabled = true }
        };

        var result = FeatureEvaluationService.Evaluate(feature, overrides, "user1", "admin", null);

        Assert.True(result);
    }
}
