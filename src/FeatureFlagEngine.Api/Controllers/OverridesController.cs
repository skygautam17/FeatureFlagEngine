
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeatureFlagEngine.Domain.Entities;
using System.Threading.Tasks;
using System;

[ApiController]
[Route("api/overrides")]
public class OverridesController : ControllerBase
{
    private readonly AppDbContext _db;
    public OverridesController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _db.FeatureOverrides.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(FeatureOverride model)
    {
        _db.FeatureOverrides.Add(model);
        await _db.SaveChangesAsync();
        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, FeatureOverride model)
    {
        var item = await _db.FeatureOverrides.FindAsync(id);
        if (item == null) return NotFound();

        item.UserId = model.UserId;
        item.GroupId = model.GroupId;
        item.Enabled = model.Enabled;

        await _db.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _db.FeatureOverrides.FindAsync(id);
        if (item == null) return NotFound();

        _db.FeatureOverrides.Remove(item);
        await _db.SaveChangesAsync();
        return Ok();
    }
}
