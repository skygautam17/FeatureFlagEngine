
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/evaluate")]
public class EvaluationController : ControllerBase
{
    private readonly AppDbContext _db;

    public EvaluationController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Evaluate(string featureKey, string? userId, string? groupId, string? region)
    {
        var feature = await _db.FeatureFlags.FirstOrDefaultAsync(f => f.Key == featureKey);
        if (feature == null) return NotFound();

        var overrides = await _db.FeatureOverrides
            .Where(o => o.FeatureFlagId == feature.Id)
            .ToListAsync();

        var result = FeatureEvaluationService.Evaluate(feature, overrides, userId, groupId, region);

        return Ok(new { featureKey, enabled = result });
    }
}
