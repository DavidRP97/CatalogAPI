using CatalogAPI_BLL.Models;
using CatalogAPI_DAL.Context;
using CatalogAPI_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Repositories
{
    public class CategoriesREP : GenericRepDAL<Categories>, ICategoriesDA
    {
        private readonly AppDbContext _appDbContext;
        public CategoriesREP(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Categories GetID(int id)
        {
            throw new System.NotImplementedException();
        }

        //public Categories GetID(int id)
        //{
        //    var categoryId = _appDbContext.Categories.FirstOrDefault(x => x.CategoryId == id);

        //    return categoryId;
        //}

        public async Task<IEnumerable<Categories>> GetWithProducts()
        {
            return await _appDbContext.Categories.Include(x => x.Products).ToListAsync();
        }
    }
}
