
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System;

[ApiController]
[Route("api/features")]
public class FeaturesController : ControllerBase
{
    private readonly IMediator _mediator;
    public FeaturesController(IMediator mediator)=>_mediator=mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllFeaturesQuery()));

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureCommand cmd)
        => Ok(await _mediator.Send(cmd));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateFeatureCommand cmd)
    {
        if (id != cmd.Id) return BadRequest();
        return Ok(await _mediator.Send(cmd));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
        => Ok(await _mediator.Send(new DeleteFeatureCommand(id)));
}
