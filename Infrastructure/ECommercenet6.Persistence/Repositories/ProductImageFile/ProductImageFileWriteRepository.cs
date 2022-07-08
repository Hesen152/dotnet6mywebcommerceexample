using ECommercenet6.Application.Repositories;
using ECommercenet6.Persistence.Contexts;

namespace ECommercenet6.Persistence.Repositories.ProductImageFile;

public class ProductImageFileWriteRepository:WriteRepository<Domain.ProductImageFile>,IProductImageFileWriteRepository
{
    public ProductImageFileWriteRepository(ECommercenet6ApiDbContext context) : base(context)
    {
    }
}