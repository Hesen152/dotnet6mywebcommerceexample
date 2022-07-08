using ECommercenet6.Application.Repositories;
using ECommercenet6.Persistence.Contexts;

namespace ECommercenet6.Persistence.Repositories.File;

public class FileWriteRepository:WriteRepository<Domain.Entities.File>,IFileWriteRepository
{
    public FileWriteRepository(ECommercenet6ApiDbContext context) : base(context)
    {
    }
}