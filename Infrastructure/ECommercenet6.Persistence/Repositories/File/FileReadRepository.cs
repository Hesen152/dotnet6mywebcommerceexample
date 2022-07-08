using ECommercenet6.Application.Repositories;
using ECommercenet6.Persistence.Contexts;

namespace ECommercenet6.Persistence.Repositories.File;

public class FileReadRepository:ReadRepository<Domain.Entities.File>,IFileReadRepository
{
    public FileReadRepository(ECommercenet6ApiDbContext context) : base(context)
    {
    }
}