using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApplication.Model;

[Table("regions")]
public class Region
{
    [Column("id")]
    public int Id  { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("locale")]
    public string Locale { get; set; }
    
    [Column("code")]
    public string Code { get; set; }
    
    [Column("city")]
    public string? City { get; set; }
    
    [Column("status")]
    public bool IsActive { get; set; }
    
    [Column("Email")]
    public  string Email {get; }
    
    public ICollection<Categories>  Categories { get; set; }
}