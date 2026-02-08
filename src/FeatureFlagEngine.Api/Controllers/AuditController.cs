using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using FeatureFlagEngine.Application.Audit;

[ApiController]
[Route("api/audit")]
public class AuditController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuditController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetLogs()
    {
        var result = await _mediator.Send(new GetAuditLogsQuery());
        return Ok(result);
    }
}
