using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;

[ApiController]
[Route("api/evaluate")]
public class EvaluationController : ControllerBase
{
    private readonly IMediator _mediator;

    public EvaluationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Evaluate(
        string featureKey,
        string? userId,
        string? groupId,
        string? region)
    {
        var result = await _mediator.Send(new EvaluateFeatureQuery
        {
            FeatureKey = featureKey,
            UserId = userId,
            GroupId = groupId,
            Region = region
        });

        return Ok(new
        {
            featureKey,
            enabled = result
        });
    }
}
