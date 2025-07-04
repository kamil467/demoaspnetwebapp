using DemoWebApplication.Model;
using DemoWebApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApplication.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RegionController: ControllerBase
{
    private readonly FontyDbContext _fontyDBContext;

    public RegionController(FontyDbContext fontyDBContext)
    {
        _fontyDBContext = fontyDBContext;
    }

    [HttpGet("get-region-by-code/{code}")]
    public async Task<IActionResult> GetRegionByCode(string code)
    {
        var region = await _fontyDBContext
            .Regions
            .Where(r => r.Code == code)
            .FirstOrDefaultAsync();
        return  Ok(region);
    }
}