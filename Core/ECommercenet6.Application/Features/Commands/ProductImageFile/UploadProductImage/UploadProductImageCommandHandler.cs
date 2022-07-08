﻿using MediatR;

namespace ECommercenet6.Application.Features.Commands.ProductImageFile.UploadProductImage;

public class UploadProductImageCommandHandler:IRequestHandler<UploadProductImageCommandRequest,UploadProductImageCommandResponse>
{
    public Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}