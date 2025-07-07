using DemoWebApplication.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApplication.Repository;

public class FontyDbContext: DbContext
{
    public DbSet<Region>  Regions { get; set; }

    public FontyDbContext(DbContextOptions<FontyDbContext> options)
    : base (options){
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Region>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Region>()
            .Property(r => r.City)
            .HasColumnName("City");
    }
    
}