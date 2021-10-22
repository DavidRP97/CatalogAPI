using CatalogAPI_BLL.Models;
using CatalogAPI_DAL.Context;
using CatalogAPI_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Repositories
{
    public class ProductREP : GenericRepDAL<Product>, IProductDA
    {
        private readonly AppDbContext _appDbContext;
        public ProductREP(AppDbContext appDbContext):base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Product>> GetAllWithCategories()
        {
            return await _appDbContext.Products.AsNoTracking().Include(x => x.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId)
        {
            return await _appDbContext.Products.AsNoTracking().Include(x => x.Category).Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public string GetProductName(int id)
        {
            return _appDbContext.Products.Where(x => x.ProductId == id).Select(x => x.Name).FirstOrDefault();
        }
    }
}
