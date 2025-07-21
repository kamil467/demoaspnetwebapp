using AutoMapper;
using AutoMapper.QueryableExtensions;
using DemoWebApplication.DTO;
using DemoWebApplication.Model;
using DemoWebApplication.Repository;
using DemoWebApplication.Utility;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApplication.Service;

public class RegionService: IRegionService
{
    private readonly FontyDbContext _context;
    private readonly IMapper _mapper;
    private IServiceLogger _logger;
    public RegionService(FontyDbContext context,
        IServiceLogger logger,
        IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    ///  Returns region and category data by region code.
    /// using without Automapper.
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public async Task<List<RegionCategoryDTO>> GetRegionCategoryByCode(string code)
    {
        _logger.Log("Info","GetRegionCategoryByCode called");
        var query =  await _context.Regions
            .Where(r => r.Code == code)
            .Include(r => r.Categories).ToListAsync();
            var dTOList = query
            .Select(regionCat => new RegionCategoryDTO
            {
                RegionCode = regionCat.Code,
                RegionCity = regionCat.City,
                RegionName = regionCat.Name,
               // RegionEmail = regionCat.Email,
                RegionIsActive = regionCat.IsActive,
                CategoryDtos = regionCat.Categories.Select(cat => new CategoryDTO
                {
                    CategoryName = cat.Name,
                    CategoryDescription = cat.Description,
                }).ToList()
            }).ToList();
            
            return dTOList;
    }

    /// <summary>
    /// Example for ProjectTo
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<List<RegionCategoryDTO>> GetRegionCategoryByName(string name)
    {
        
        Console.WriteLine($"GetRegionCategoryByName With ProjectTo");
        // using projectTo
       //  var result =  await _context.Regions.Where(r => r.Name == name)
           //   .ProjectTo<RegionCategoryDTO>(_mapper.ConfigurationProvider).ToListAsync();

         
       // using Include and Map.
       Console.WriteLine("Automapper with Include and Map");
       var result1 = await _context.Regions
           .Where(r => r.Name == name)
           .Include(cat => cat.Categories)
           .ToListAsync();
     var mapperResult =   _mapper.Map<List<RegionCategoryDTO>>(result1);
          
         return mapperResult;
         
    }
}