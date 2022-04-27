using ECommercenet6.Domain.Entities;

namespace ECommercenet6.Application.Abstractions;

public interface IProductService
{
    List<Product> GetProducts();
}