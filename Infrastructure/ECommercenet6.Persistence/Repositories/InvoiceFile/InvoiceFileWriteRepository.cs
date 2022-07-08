using ECommercenet6.Application.Repositories;
using ECommercenet6.Domain;
using ECommercenet6.Persistence.Contexts;

namespace ECommercenet6.Persistence.Repositories.InvoiceFile;

public class InvoiceFileWriteRepository:WriteRepository<InVoiceFile>,IInvoiceFileWriteRepository
{
    public InvoiceFileWriteRepository(ECommercenet6ApiDbContext context) : base(context)
    {
        
    }
}