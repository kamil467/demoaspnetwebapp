using DemoWebApplication.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApplication.Repository;

public class FontyDbContext: DbContext
{
    public DbSet<Region>  Regions { get; set; }

    public DbSet<Categories>  Categories { get; set; }
    public FontyDbContext(DbContextOptions<FontyDbContext> options)
    : base (options){
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Region>()
            .HasKey(r => r.Id);

       modelBuilder.Entity<Region>().Property(r => r.Email);

       modelBuilder.Entity<Region>()
           .HasMany(r => r.Categories)
           .WithMany(c => c.Regions)
           .UsingEntity(m =>
           {
               m.ToTable("regions_categories_mapping");
               m.Property<int>("RegionsId").HasColumnName("region_id");
               m.Property<int>("categoriesId").HasColumnName("category_id");
           });



    }
    
}