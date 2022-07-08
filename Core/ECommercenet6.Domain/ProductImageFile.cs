using ECommercenet6.Domain.Entities;
using File = ECommercenet6.Domain.Entities.File;

namespace ECommercenet6.Domain;

public class ProductImageFile:File
{
    public ICollection<Product> Products { get; set; }
    
}