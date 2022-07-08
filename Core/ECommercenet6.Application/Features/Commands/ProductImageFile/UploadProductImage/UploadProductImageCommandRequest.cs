using MediatR;

namespace ECommercenet6.Application.Features.Commands.ProductImageFile.UploadProductImage;

public class UploadProductImageCommandRequest:IRequest<UploadProductImageCommandResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}