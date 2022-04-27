using System.Data;
using ECommercenet6.Application.ViewModels.Products;
using FluentValidation;

namespace ECommercenet6.Application.Validators.Products;

public class CreateProductValidator:AbstractValidator<VM_Create_Product>
{

    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull().WithMessage("Please enter a product name")
            .MaximumLength(150)
            .MinimumLength(5)
            .WithMessage("Product name must be between 5 and 150 characters");
        
        
        RuleFor(p=>p.Stock) 
            .NotEmpty()
            .NotNull().WithMessage("Please enter a stock")
            .Must(s=>s>=0)
            .WithMessage("Stock must be greater than 0");
        RuleFor(p=>p.Price)
            .NotEmpty()
            .NotNull().WithMessage("Please enter a price")
            .Must(p=>p>=0)
            .WithMessage("Price must be greater than 0");
        
    }
}