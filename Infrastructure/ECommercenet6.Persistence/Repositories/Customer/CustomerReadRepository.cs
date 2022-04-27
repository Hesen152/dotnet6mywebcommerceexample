using ECommercenet6.Application.Repositories;
using ECommercenet6.Domain.Entities;
using ECommercenet6.Persistence.Contexts;

namespace ECommercenet6.Persistence.Repositories;

public class CustomerReadRepository:ReadRepository<Customer>,ICustomerReadRepository
{
    public CustomerReadRepository(ECommercenet6ApiDbContext context) : base(context)
    {
    }
}