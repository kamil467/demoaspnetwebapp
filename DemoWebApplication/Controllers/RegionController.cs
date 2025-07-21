using DemoWebApplication.DTO.Request;
using DemoWebApplication.Middlewares;
using DemoWebApplication.Model;
using DemoWebApplication.Repository;
using DemoWebApplication.Service;
using DemoWebApplication.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApplication.Controllers;
[ApiController]
[AddCustomHeader]
[Route("api/[controller]")]
public class RegionController: ControllerBase
{
   private readonly IRegionService _regionService;
   private readonly IServiceLogger _logger;

    public RegionController(IRegionService  regionService,
        IServiceLogger logger)
    {
        _regionService = regionService;
        _logger = logger;
    }

    [HttpGet("get-region-by-code/{code}")]
    public async Task<IActionResult> GetRegionByCode(
        [FromHeader(Name="x-Code")] string? xCode,   
        string code)
    {
        var isModelValid = ModelState.IsValid;
        _logger.Log("Info","GetRegionByCodeActionMethod called");
        var regionAndCategoriesData = await _regionService.GetRegionCategoryByCode(code);
        return  Ok(regionAndCategoriesData);
    }

    [HttpGet("get-region-by-name/{name}")]
    public async Task<IActionResult> GetRegionByName(string name)
    {
        var  regionAndCategoriesData = await _regionService.GetRegionCategoryByName(name);
        return Ok(regionAndCategoriesData);
    }

    [HttpPost("create-region")]
    public async Task<IActionResult> CreateRegion([FromBody] CreateRegionDTO dto)
    {
        var isModelValid = ModelState.IsValid;
        return Created();
    }
    
    
    
}