using CatalogAPI_BLL.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_SERVICES.Interfaces
{
    public interface ICategoryServices
    {
        Task<Categories> ChangeCategory(Categories categories);
        Task DeleteCategory(ObjectId id);
        Task<Categories> GetCategorytById(ObjectId id);
        Task<IEnumerable<Categories>> GetCategories();
        Task<Categories> SaveCategory(Categories product);
    }
}
