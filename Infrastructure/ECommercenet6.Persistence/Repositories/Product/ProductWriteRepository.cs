using ECommercenet6.Application.Repositories;
using ECommercenet6.Domain.Entities;
using ECommercenet6.Persistence.Contexts;

namespace ECommercenet6.Persistence.Repositories;

public class ProductWriteRepository:WriteRepository<Product>,IProductWriteRepository
{
    public ProductWriteRepository(ECommercenet6ApiDbContext context) : base(context)
    {
    }
}