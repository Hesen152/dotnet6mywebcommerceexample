using ECommercenet6.Application.Features.Commands.Product.UpdateProduct;
using MediatR;

namespace ECommercenet6.Application.Features.Commands.Product.RemoveProduct;

public class RemoveProductCommandRequest:IRequest<RemoveProductCommandResponse>
{
    public string Id { get; set; }
}