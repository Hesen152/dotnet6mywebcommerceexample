using ECommercenet6.Application.Repositories;
using ECommercenet6.Domain.Entities.Common;
using ECommercenet6.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommercenet6.Persistence.Repositories;

public class WriteRepository<T>:IWriteRepository<T> where T:BaseEntity
{
    private readonly  ECommercenet6ApiDbContext _context;

    public WriteRepository(ECommercenet6ApiDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    
    public async  Task<bool> AddAsync(T data)
    {

        EntityEntry entityEntry = await Table.AddAsync(data);
        return entityEntry.State == EntityState.Added;
        


    }

    public async  Task<bool> AddRangeAsync(List<T> data)
    {
       await   Table.AddRangeAsync(data);
       return true;
       
        throw new NotImplementedException();
    }

    public bool Remove(T data)
    {
       EntityEntry entityEntry= Table.Remove(data);
      return  entityEntry.State == EntityState.Deleted;
      
    }

    public bool RemoveRange(List<T> datas)
    {
       Table.RemoveRange(datas);
       return true;

    }

    public async Task<bool> RemoveAsync(string id)
    {
      T model= await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
      return Remove(model);
      

    }

    public   bool Update(T data)
    {
      EntityEntry entityEntry =  Table.Update(data);
      return   entityEntry.State == EntityState.Modified;
    }


    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();
}