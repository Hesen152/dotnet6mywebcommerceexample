using MediatR;

namespace ECommercenet6.Application.Features.Queries.Product.GetAllProducts;

public class GetAllProductQueryRequest:IRequest<GetAllProductQueryResponse>
{
   public int Page { get; set; } = 0;
   public int Size { get; set; } = 5;   

}