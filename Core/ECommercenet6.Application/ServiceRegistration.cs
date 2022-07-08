using System.Collections;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercenet6.Application;

public static class ServiceRegistration
{
    
    public static void  AddApplicationServices(this IServiceCollection collection)
    {

        collection.AddMediatR(typeof(ServiceRegistration));
        

    }
}