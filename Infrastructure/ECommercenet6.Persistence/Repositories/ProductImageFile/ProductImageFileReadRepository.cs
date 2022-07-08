using ECommercenet6.Application.Repositories;
using ECommercenet6.Persistence.Contexts;

namespace ECommercenet6.Persistence.Repositories.ProductImageFile;

public class ProductImageFileReadRepository:ReadRepository<Domain.ProductImageFile>,IProductImageFileReadRepository
{
    public ProductImageFileReadRepository(ECommercenet6ApiDbContext context) : base(context)
    {
    }
}