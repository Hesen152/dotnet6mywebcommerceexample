using ECommercenet6.Domain.Entities.Common;

namespace ECommercenet6.Domain.Entities;

public class Order:BaseEntity
{
    public Guid CustomerId { get; set; }
    public string Description { get; set; }
    public string Adress { get; set; }
    public ICollection<Product> Products { get; set; }
    public Customer  Customer { get; set; }

    
}