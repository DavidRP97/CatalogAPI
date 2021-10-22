using CatalogAPI.JWT_Configuration;
using CatalogAPI.JWT_Configuration.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.WebAPI_Dependency_Injection_Config
{
    public static class WebApiDIConfig
    {
        public static void ConfigureDIWebConfig(this IServiceCollection services)
        {
            services.AddTransient<ITokenGenerate, TokenGenerate>();;
        }
    }
}
