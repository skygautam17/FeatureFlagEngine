using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/overrides")]
public class OverridesController : ControllerBase
{
    private readonly IMediator _mediator;

    public OverridesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllOverridesQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOverrideCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateOverrideCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteOverrideCommand { Id = id });

        if (!result)
            return NotFound();

        return Ok();
    }
}
