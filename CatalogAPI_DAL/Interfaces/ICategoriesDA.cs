using CatalogAPI_BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Interfaces
{
    public interface ICategoriesDA : IGenericDAL<Categories>
    {
        Categories GetID(int id);
        Task<IEnumerable<Categories>> GetWithProducts();
    }
}
