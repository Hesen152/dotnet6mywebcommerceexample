using System.Net;
using ECommercenet6.Application.Abstractions;
using ECommercenet6.Application.Abstractions.Storage;
using ECommercenet6.Application.Features.Commands.Product.CreateProduct;
using ECommercenet6.Application.Features.Commands.Product.RemoveProduct;
using ECommercenet6.Application.Features.Commands.Product.UpdateProduct;
using ECommercenet6.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using ECommercenet6.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ECommercenet6.Application.Features.Queries.Product.GetAllProducts;
using ECommercenet6.Application.Features.Queries.Product.GetByIdProduct;
using ECommercenet6.Application.Features.Queries.ProductImageFile.GetProductImages;
using ECommercenet6.Application.Repositories;
using ECommercenet6.Application.RequestParameters;
using ECommercenet6.Application.Services;
using ECommercenet6.Application.ViewModels.Products;
using ECommercenet6.Domain;
using ECommercenet6.Domain.Entities;
using ECommercenet6.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommercenet6.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IProductReadRepository _productReadRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IFileService _fileService;
    readonly IFileReadRepository _fileReadRepository;
    readonly IFileWriteRepository _fileWriteRepository;
    readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
    readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
    readonly IProductImageFileReadRepository _productImageFileReadRepository;
    private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
    readonly IStorageService _storageService;
    private readonly IConfiguration _configuration;

    private readonly IMediator _mediator;


    public ProductsController(IMediator mediator)
    {
       
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
    {
        GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
        return Ok(response);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest request)
    {
        GetByIdProductQueryResponse response = await _mediator.Send(request);

        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommandRequest commandRequest)
    {
        //
        // if (ModelState.IsValid)
        // {
        //     
        // } 

        CreateProductCommandResponse response = await _mediator.Send(commandRequest);

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest request)
    {
        UpdateProductCommandResponse response = await _mediator.Send(request);
        return Ok();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest request)
    {
        RemoveProductCommandResponse response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest
        uploadProductImageCommandRequest)
    {

        uploadProductImageCommandRequest.FormFileCollection = Request.Form.Files;
      UploadProductImageCommandResponse response= await _mediator.Send(uploadProductImageCommandRequest);


        return Ok();
    }


    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetProductImages([FromRoute]GetProductImagesFileQueryRequest
        getProductImagesFileQueryRequest)
    {
        List<GetProductImagesFileQueryResponse> response = await _mediator.Send(getProductImagesFileQueryRequest) ;
        return Ok(response);


    }

    [HttpDelete("[action]/{Id}")]
    public async Task<IActionResult> DeleteProductImage([FromRoute]RemoveProductImageCommandRequest 
    removeProductImageCommandRequest,[FromQuery] string imageId)
    {

        removeProductImageCommandRequest.ImageId = imageId;
        RemoveProductImageCommandResponse response =  await _mediator.Send(removeProductImageCommandRequest);
        
        return Ok();
    }
}