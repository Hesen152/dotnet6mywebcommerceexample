using ECommercenet6.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommercenet6.Application.Features.Queries.ProductImageFile.GetProductImages;

public class GetProductImagesQueryHandler:IRequestHandler<GetProductImagesFileQueryRequest,List<GetProductImagesFileQueryResponse>>
{

    private IProductReadRepository _productReadRepository;
    private IConfiguration configuration;

    public GetProductImagesQueryHandler(IProductReadRepository productReadRepository, IConfiguration configuration)
    {
        _productReadRepository = productReadRepository;
        this.configuration = configuration;
    }

    public async  Task<List<GetProductImagesFileQueryResponse>> Handle(GetProductImagesFileQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
            .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

        return product.ProductImageFiles.Select(p => new GetProductImagesFileQueryResponse
        {
            Path = $"{configuration["BaseStorageUrl"]}/{p.Path}",
             Id = p.Id,
             FileName = p.FileName
             
        }).ToList();
    }
}