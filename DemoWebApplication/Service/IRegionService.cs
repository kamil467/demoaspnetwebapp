
using DemoWebApplication.DTO;
namespace DemoWebApplication.Service;

public interface IRegionService
{
    Task<List<RegionCategoryDTO>> GetRegionCategoryByCode(string code);
    Task<List<RegionCategoryDTO>> GetRegionCategoryByName(string name);
}