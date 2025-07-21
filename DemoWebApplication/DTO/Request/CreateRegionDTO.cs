using System.ComponentModel.DataAnnotations;

namespace DemoWebApplication.DTO.Request;

public class CreateRegionDTO
{
    [Required]
    public string? Code { get; set; }
    
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; } 
    public string? Locale { get; set; }
    public string? Email { get; set; }
    public bool? Status { get; set; }
}