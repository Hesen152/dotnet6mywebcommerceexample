using System.Net.Security;
using ECommercenet6.Application.Abstractions;
using ECommercenet6.Application.Repositories;
using ECommercenet6.Persistence.Contexts;
using ECommercenet6.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercenet6.Persistence;

public static class ServiceRegistiration
{
    public static  void AddPersistanceServices(this IServiceCollection services)
    {
        services.AddDbContext<ECommercenet6ApiDbContext>(options =>
            options.UseNpgsql(Configuration.ConnectionString));

        // services.AddSingleton<IProductService, ProductService>();
        services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
        services.AddScoped<IOrderReadRepository,OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository,OrderWriteRepository>();
        services.AddScoped<IProductReadRepository,ProductReadRepository>();
        services.AddScoped<IProductWriteRepository,ProductWriteRepository>();

    }
    
}