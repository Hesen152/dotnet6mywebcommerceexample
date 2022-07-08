using MediatR;

namespace ECommercenet6.Application.Features.Queries.Product.GetByIdProduct;

public class GetByIdProductQueryRequest:IRequest<GetByIdProductQueryResponse>
{
    public string Id { get; set; }
}