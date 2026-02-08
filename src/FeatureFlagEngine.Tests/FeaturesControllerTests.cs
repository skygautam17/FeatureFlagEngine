
using Xunit;
using FeatureFlagEngine.Domain.Entities;

public class FeaturesControllerTests
{
    [Fact]
    public async Task Should_Create_Feature()
    {
        var db = TestDbContextFactory.Create();
        var controller = new FeaturesController(db);

        var feature = new FeatureFlag
        {
            Key = "TestFeature",
            Description = "Test",
            Enabled = true
        };

        var result = await controller.Create(feature);

        Assert.NotNull(result);
        Assert.Equal(1, db.FeatureFlags.Count());
    }
}
