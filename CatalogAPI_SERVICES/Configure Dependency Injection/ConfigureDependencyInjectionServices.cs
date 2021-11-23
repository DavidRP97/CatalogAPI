using CatalogAPI_SERVICES.Interfaces;
using CatalogAPI_SERVICES.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_SERVICES.Configure_Dependency_Injection
{
    public static class ConfigureDependencyInjectionServices
    {
        public static void ConfigureDIServices(this IServiceCollection services)
        {
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ICategoryServices, Categoryservices>();
        }
    }
}
