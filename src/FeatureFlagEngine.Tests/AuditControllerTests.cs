using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using FeatureFlagEngine.Application.Audit;
using FeatureFlagEngine.Domain.Entities;
using System.Collections.Generic;

public class AuditControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly AuditController _controller;

    public AuditControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new AuditController(_mediatorMock.Object);
    }

    [Fact]
    public async Task GetLogs_ShouldReturnOk()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAuditLogsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<AuditLog>());

        var result = await _controller.GetLogs();

        Assert.IsType<OkObjectResult>(result);
    }
}
