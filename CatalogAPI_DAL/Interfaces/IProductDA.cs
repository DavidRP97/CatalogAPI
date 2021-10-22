using CatalogAPI_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Interfaces
{
    public interface IProductDA : IGenericDAL<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryId(int categoryId);
        Task<IEnumerable<Product>> GetAllWithCategories();
        string GetProductName(int id);
    }
}
