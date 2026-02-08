using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FeatureFlagEngine.Domain.Entities;

public class FeaturesControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly FeaturesController _controller;

    public FeaturesControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new FeaturesController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnOk()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllFeaturesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<FeatureFlag>());

        var result = await _controller.GetAll();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Create_ShouldReturnOk()
    {
        var command = new CreateFeatureCommand(Guid.NewGuid().ToString(), "Test", true);

        _mediatorMock
            .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new FeatureFlag());

        var result = await _controller.Create(command);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Update_ShouldReturnBadRequest_WhenIdMismatch()
    {
        var cmd = new UpdateFeatureCommand(
            Guid.NewGuid(),
            "FeatureA",
            "Test feature",
            true
        );

        var result = await _controller.Update(Guid.NewGuid(), cmd);

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task Update_ShouldReturnOk_WhenValid()
    {
        Guid id = Guid.NewGuid();
        var cmd = new UpdateFeatureCommand(
            id,
            "FeatureA",
            "Test feature",
            true
        );

        _mediatorMock
            .Setup(m => m.Send(cmd, It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _controller.Update(id, cmd);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Delete_ShouldReturnOk()
    {
        var id = Guid.NewGuid();

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<DeleteFeatureCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _controller.Delete(id);

        Assert.IsType<OkObjectResult>(result);
    }
}
