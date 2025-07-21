using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DemoWebApplication.Model;

[Table("categories")]
public class Categories
{
    [Column("id")]
    [Key]
    public int Id  { get; set; }
    
    [Column("name")]
    public string Name  { get; set; }
    
    [Column("isActive")]
    public bool IsActive { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    public ICollection<Region> Regions { get; set; }
}