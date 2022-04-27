using ECommercenet6.Domain.Entities.Common;

namespace ECommercenet6.Application.Repositories;

public interface IWriteRepository<T>:IRepository<T> where T:BaseEntity
{
  Task<bool> AddAsync(T data);
  Task<bool> AddRangeAsync(List<T> data);
  bool Remove(T data);
  bool RemoveRange(List<T> datas );
  
   Task<bool> RemoveAsync (string id);
  bool Update(T data);
  Task<int> SaveChangesAsync();
}