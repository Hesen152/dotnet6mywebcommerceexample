using ECommercenet6.Application.Repositories;
using ECommercenet6.Domain;
using ECommercenet6.Persistence.Contexts;

namespace ECommercenet6.Persistence.Repositories.InvoiceFile;

public class InvoiceFileReadRepository:ReadRepository<InVoiceFile>,IInvoiceFileReadRepository
{
    public InvoiceFileReadRepository(ECommercenet6ApiDbContext context) : base(context)
    {
        
    }
}