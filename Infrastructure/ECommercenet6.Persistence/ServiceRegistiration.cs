using System.Net.Security;
using ECommercenet6.Application.Abstractions;
using ECommercenet6.Application.Repositories;
using ECommercenet6.Domain.Entities.Identity;
using ECommercenet6.Persistence.Contexts;
using ECommercenet6.Persistence.Repositories;
using ECommercenet6.Persistence.Repositories.File;
using ECommercenet6.Persistence.Repositories.InvoiceFile;
using ECommercenet6.Persistence.Repositories.ProductImageFile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercenet6.Persistence;

public static class ServiceRegistiration
{
    public static  void AddPersistanceServices(this IServiceCollection services)
    {
        services.AddDbContext<ECommercenet6ApiDbContext>(options =>
            options.UseNpgsql(Configuration.ConnectionString));
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            
        }).AddEntityFrameworkStores<ECommercenet6ApiDbContext>();
        

        // services.AddSingleton<IProductService, ProductService>();
        services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
        services.AddScoped<IOrderReadRepository,OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
        services.AddScoped<IProductReadRepository,ProductReadRepository>();
        services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
          services.AddScoped<IFileReadRepository,FileReadRepository>();
                services.AddScoped<IFileWriteRepository,FileWriteRepository>();
                services.AddScoped<IFileReadRepository,FileReadRepository>();
                services.AddScoped<IProductImageFileReadRepository,ProductImageFileReadRepository>();
                services.AddScoped<IProductImageFileWriteRepository,ProductImageFileWriteRepository>();
                services.AddScoped<IInvoiceFileReadRepository,InvoiceFileReadRepository>();
                services.AddScoped<IInvoiceFileWriteRepository,InvoiceFileWriteRepository>();

    }
    
}