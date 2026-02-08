using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FeatureFlagEngine.Domain.Entities;

public class FeatureToggleControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly FeatureToggleController _controller;

    public FeatureToggleControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new FeatureToggleController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Execute_ShouldReturnNotFound_WhenFeatureMissing()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllFeaturesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<FeatureFlag>());

        var result = await _controller.Execute("missing");

        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task Execute_ShouldReturnNewEndpoint_WhenEnabled()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllFeaturesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<FeatureFlag>
            {
                new FeatureFlag { Key = "F1", Enabled = true }
            });

        var result = await _controller.Execute("F1");

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Execute_ShouldReturnOldEndpoint_WhenDisabled()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllFeaturesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<FeatureFlag>
            {
                new FeatureFlag { Key = "F1", Enabled = false }
            });

        var result = await _controller.Execute("F1");

        Assert.IsType<OkObjectResult>(result);
    }
}
