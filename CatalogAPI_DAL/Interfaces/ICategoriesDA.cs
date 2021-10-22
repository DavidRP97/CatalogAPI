using CatalogAPI_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Interfaces
{
    public interface ICategoriesDA : IGenericDAL<Categories>
    {
        Categories GetID(int id);
        Task<IEnumerable<Categories>> GetWithProducts();
    }
}
