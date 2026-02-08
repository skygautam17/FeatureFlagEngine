using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

public class EvaluationControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly EvaluationController _controller;

    public EvaluationControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new EvaluationController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Evaluate_ShouldReturnOk()
    {
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<EvaluateFeatureQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _controller.Evaluate("Feature1", "user1", "group1", "IN");

        Assert.IsType<OkObjectResult>(result);
    }
}
