using ECommerce.Application.Contracts;
using ECommerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application
{
    public static class ApplicationServicesRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddAutoMapper(C => { },typeof(ApplicationServicesRegister).Assembly);
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
