using System.Collections;
using System.Diagnostics.SymbolStore;
using ECommercenet6.Application.Abstractions.Storage;
using ECommercenet6.Application.Abstractions.Token;
using ECommercenet6.Application.Services;
using ECommercenet6.Infrastructure.Services;
using ECommercenet6.Infrastructure.Services.Storage;
using ECommercenet6.Infrastructure.Services.Storage.Azure;
using ECommercenet6.Infrastructure.Services.Storage.Enum;
using ECommercenet6.Infrastructure.Services.Storage.Local;
using ECommercenet6.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercenet6.Infrastructure;

public static class ServiceRegistiration
{

    public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
    {
        //serviceCollection.AddScoped<IFileService, FileService>();
        serviceCollection.AddScoped<IStorageService, StorageService>();
        serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        
    }

    public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
    {
        serviceCollection.AddScoped<IStorage, T>();
    }
    
    
    public static void AddStorage<T>(this IServiceCollection serviceCollection,StorageType storageType)
    {
        switch (storageType)
        {
            case StorageType.Local:
                serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
            case StorageType.Azure:
                serviceCollection.AddScoped<IStorage, AzureStorage>();
                break;
            
            case StorageType.AWS:
                break;
            
            default:
                serviceCollection.AddScoped<IStorage, LocalStorage>();
                break;
                
                
                
                
            
        }
    }

}