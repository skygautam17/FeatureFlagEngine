
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Linq;

[ApiController]
[Route("api/feature-toggle")]
public class FeatureToggleController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeatureToggleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Calls different logic based on feature flag
    [HttpGet("{key}")]
    public async Task<IActionResult> Execute(string key)
    {
        var features = await _mediator.Send(new GetAllFeaturesQuery());
        var feature = features.FirstOrDefault(f => f.Key == key);

        if (feature == null)
            return NotFound("Feature not found");

        if (feature.Enabled)
            return Ok(new { message = "NEW endpoint executed because feature is ON" });
        else
            return Ok(new { message = "OLD endpoint executed because feature is OFF" });
    }
}
