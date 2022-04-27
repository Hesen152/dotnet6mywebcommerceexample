using ECommercenet6.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommercenet6.Application.Repositories;

public interface IRepository<T> where T:BaseEntity 
{
    DbSet<T> Table { get; }
    
}