using ECommercenet6.Domain;
using ECommercenet6.Domain.Entities;
using ECommercenet6.Domain.Entities.Common;
using ECommercenet6.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = ECommercenet6.Domain.Entities.File;

namespace ECommercenet6.Persistence.Contexts;

public class ECommercenet6ApiDbContext:IdentityDbContext<AppUser,AppRole,string>
{
  public ECommercenet6ApiDbContext(DbContextOptions options):base(options)
  {
    
    
  }

  public DbSet<Product> Products { get; set; }
  public DbSet<Order> Orders { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<File> Files { get; set; }
  public DbSet<ProductImageFile> ProductImageFiles { get; set; }
  public DbSet<InVoiceFile> InVoiceFiles { get; set; }
  

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    var datas=  ChangeTracker.Entries<BaseEntity>();
    foreach (var data in datas)
    {
      _= data.State switch
      {
        EntityState.Added => data.Entity.CreatedDate=DateTime.UtcNow,
        EntityState.Modified =>data.Entity.UpdatedDate=DateTime.UtcNow,
        _=>DateTime.UtcNow
      };

    }
      return await  base.SaveChangesAsync(cancellationToken);
  }
}