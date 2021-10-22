using CatalogAPI_DAL.Interfaces;
using CatalogAPI_DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Dependecy_Injection_Config
{
    public static class ConfigureDependencyInjection
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddTransient<ICategoriesDA, CategoriesREP>();
            services.AddTransient<IProductDA, ProductREP>();
        }
    }
}
