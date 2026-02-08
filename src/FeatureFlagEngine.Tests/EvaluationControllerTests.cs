
using Xunit;
using FeatureFlagEngine.Domain.Entities;

public class EvaluationControllerTests
{
    [Fact]
    public async Task Should_Return_NotFound_When_Feature_Not_Exists()
    {
        var db = TestDbContextFactory.Create();
        var controller = new EvaluationController(db);

        var result = await controller.Evaluate("MissingFeature", null, null, null);

        Assert.NotNull(result);
    }
}
