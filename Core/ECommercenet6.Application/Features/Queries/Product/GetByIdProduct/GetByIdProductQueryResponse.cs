using ECommercenet6.Domain.Entities;

namespace ECommercenet6.Application.Features.Queries.Product.GetByIdProduct;

public class GetByIdProductQueryResponse
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<Domain.ProductImageFile> ProductImageFiles { get; set; }

}