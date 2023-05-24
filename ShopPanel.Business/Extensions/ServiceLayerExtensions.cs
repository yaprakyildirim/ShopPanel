using Microsoft.Extensions.DependencyInjection;
using ShopPanel.Business.Services.Abstract;
using ShopPanel.Business.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.Business.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IStoreService, StoreService>();

            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
