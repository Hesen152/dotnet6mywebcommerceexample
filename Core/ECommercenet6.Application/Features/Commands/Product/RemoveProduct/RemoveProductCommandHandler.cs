﻿using MediatR;

namespace ECommercenet6.Application.Features.Commands.Product.UpdateProduct;

public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommandRequest,UpdateProductCommandResponse>
{
    public Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}