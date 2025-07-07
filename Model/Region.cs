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
    
    [Column("City")]
    public string? City { get;}
}