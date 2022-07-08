using MediatR;

namespace ECommercenet6.Application.Features.Commands.Product.UpdateProduct;

public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}