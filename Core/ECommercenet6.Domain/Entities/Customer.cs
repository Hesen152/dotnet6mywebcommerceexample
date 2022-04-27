using ECommercenet6.Domain.Entities.Common;

namespace ECommercenet6.Domain.Entities;

public class Customer:BaseEntity
{
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; }
}