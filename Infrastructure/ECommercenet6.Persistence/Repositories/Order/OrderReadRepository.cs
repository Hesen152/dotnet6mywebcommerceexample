using ECommercenet6.Application.Repositories;
using ECommercenet6.Domain.Entities;
using ECommercenet6.Persistence.Contexts;

namespace ECommercenet6.Persistence.Repositories;

public class OrderReadRepository:ReadRepository<Order>,IOrderReadRepository
{
    public OrderReadRepository(ECommercenet6ApiDbContext context) : base(context)
    {
    }
}