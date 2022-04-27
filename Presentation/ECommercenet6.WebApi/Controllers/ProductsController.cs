using System.Net;
using ECommercenet6.Application.Abstractions;
using ECommercenet6.Application.Repositories;
using ECommercenet6.Application.ViewModels.Products;
using ECommercenet6.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECommercenet6.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProductsController:ControllerBase
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly  IProductReadRepository        _productReadRepository;



    public ProductsController(IProductWriteRepository productWriteRepository,
        IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository,
        ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
    }


    [HttpGet]
    public   IActionResult Get()
    {
        
        return   Ok(  _productReadRepository.GetAll(false));

    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {

     return Ok(await _productReadRepository.GetByIdAsync(id,false));
        
    }


    [HttpPost]
    public async Task<IActionResult> Post(VM_Create_Product model)
    {
        //
        // if (ModelState.IsValid)
        // {
        //     
        // }
       await  _productWriteRepository.AddAsync(new()
        {
            Name = model.Name,
            Price = model.Price,
            Stock = model.Stock
        });
        await _productWriteRepository.SaveChangesAsync();

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> Put(VM_Update_Product model)
    {
   
        Product product = await _productReadRepository.GetByIdAsync(model.Id);
        product.Stock = model.Stock;
        product.Name = model.Name;
        product.Price = model.Price;
        await _productWriteRepository.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async  Task<IActionResult> Delete(string id )
    {

        var deletedProduct= await _productWriteRepository.RemoveAsync(id);
        await _productWriteRepository.SaveChangesAsync();
        return Ok();


    }    
    

}