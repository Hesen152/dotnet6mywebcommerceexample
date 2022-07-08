using ECommercenet6.Application.Abstractions.Storage;
using ECommercenet6.Application.Repositories;
using MediatR;

namespace ECommercenet6.Application.Features.Commands.ProductImageFile.UploadProductImage;

public class UploadProductImageCommandHandler:IRequestHandler<UploadProductImageCommandRequest,UploadProductImageCommandResponse>
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IStorageService _storageService;
    private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
    private readonly IProductWriteRepository _productWriteRepository;
    public UploadProductImageCommandHandler(IProductReadRepository productReadRepository, IStorageService storageService, IProductImageFileWriteRepository productImageFileWriteRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _storageService = storageService;
        _productImageFileWriteRepository = productImageFileWriteRepository;
        _productWriteRepository = productWriteRepository;
    }

    public async  Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName,string pathOrContainerName)> result= await  _storageService.UploadAsync("photo-images", request.FormFileCollection );
        Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);
        // foreach (var r in result)
        // {
        //     product.ProductImageFiles.Add(new ProductImageFile()
        //     { 
        //             FileName = r.fileName,
        //             Path = r.pathOrContainerName,
        //             Storage =_storageService.StorageName,
        //             Products = new List<Product>(){product}
        //        
        //     });
        //     
        // }
        await   _productImageFileWriteRepository

            .AddRangeAsync(result.Select(c => new Domain.ProductImageFile()
            {
                FileName = c.fileName,
                Path = c.pathOrContainerName,
                Storage =_storageService.StorageName,
                Products = new List<Domain.Entities.Product>(){product}
            }).ToList());
        await _productImageFileWriteRepository.SaveChangesAsync();

        return new();
    }
}