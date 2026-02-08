using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using FeatureFlagEngine.Domain.Entities;
using System.Collections.Generic;

public class OverridesControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly OverridesController _controller;

    public OverridesControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new OverridesController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnOk()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllOverridesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<FeatureOverride>());

        var result = await _controller.GetAll();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Create_ShouldReturnOk()
    {
        var cmd = new CreateOverrideCommand();

        _mediatorMock
            .Setup(m => m.Send(cmd, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new FeatureOverride());

        var result = await _controller.Create(cmd);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Update_ShouldReturnNotFound_WhenNull()
    {
        var id = Guid.NewGuid();
        var cmd = new UpdateOverrideCommand();

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<UpdateOverrideCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((FeatureOverride)null);

        var result = await _controller.Update(id, cmd);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Update_ShouldReturnOk_WhenSuccess()
    {
        var id = Guid.NewGuid();
        var cmd = new UpdateOverrideCommand();

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<UpdateOverrideCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new FeatureOverride());

        var result = await _controller.Update(id, cmd);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Delete_ShouldReturnNotFound_WhenFalse()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<DeleteOverrideCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var result = await _controller.Delete(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Delete_ShouldReturnOk_WhenTrue()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<DeleteOverrideCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _controller.Delete(Guid.NewGuid());

        Assert.IsType<OkResult>(result);
    }
}
