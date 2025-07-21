namespace DemoWebApplication.DTO;

public class RegionCategoryDTO
{
    public string RegionName { get; set; }
    public string Locale { get; set; }
    
   
    public string RegionCode { get; set; }
    
  
    public string? RegionCity { get; set; }
    

    public bool RegionIsActive { get; set; }

   public  string RegionEmail {get; set; }
    
    public List<CategoryDTO> CategoryDtos { get; set; }  
}
