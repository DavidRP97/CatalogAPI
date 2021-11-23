using CatalogAPI_BLL.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_SERVICES.Interfaces
{
    public interface IProductServices
    {
        Task<Product> ChangeProduct(Product product);
        Task DeleteProduct(ObjectId id);
        Task<Product> GetProductById(ObjectId id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> SaveProduct(Product product);
    }
}
