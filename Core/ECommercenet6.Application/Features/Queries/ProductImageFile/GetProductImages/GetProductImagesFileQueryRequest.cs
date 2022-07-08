using MediatR;

namespace ECommercenet6.Application.Features.Queries.ProductImageFile.GetProductImages;

public class GetProductImagesFileQueryRequest:IRequest<List<GetProductImagesFileQueryResponse>>
{

    public string Id { get; set; }
}