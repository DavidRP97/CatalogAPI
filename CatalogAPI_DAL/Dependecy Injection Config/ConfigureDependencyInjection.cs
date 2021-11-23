using CatalogAPI_DAL.Context;
using CatalogAPI_DAL.Interfaces;
using CatalogAPI_DAL.Interfaces.Mongo;
using CatalogAPI_DAL.Repositories;
using CatalogAPI_DAL.Repositories.Mongo;
using CatalogAPI_DAL.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogAPI_DAL.Dependecy_Injection_Config
{
    public static class ConfigureDependencyInjection
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddTransient<ICategoriesDA, CategoriesREP>();
            services.AddTransient<IProductDA, ProductREP>();
            services.AddScoped<IProductMongoRepository, ProductMongoRepository>();
            services.AddScoped<ICategoryMongoRepository, CategoryMongoRepository>();
            services.AddScoped<IMongoDBContext, MongoDBContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
