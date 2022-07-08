using ECommercenet6.Application.Features.Commands.Product.RemoveProduct;
using ECommercenet6.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommercenet6.Application.Features.Commands.ProductImageFile.RemoveProductImage;

public class RemoveProductImageHandler:IRequestHandler<RemoveProductImageCommandRequest,RemoveProductImageCommandResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public RemoveProductImageHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    public async  Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        
        Domain.Entities.Product? product = await _productReadRepository.Table.Include(c => c.ProductImageFiles)
            .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
        Domain.ProductImageFile? productImageFile = product?.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));
        if (productImageFile!=null )
                product?.ProductImageFiles.Remove(productImageFile);
        
        await _productWriteRepository.SaveChangesAsync();

        return new();
    }
}