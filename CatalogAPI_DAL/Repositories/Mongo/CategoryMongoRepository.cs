using CatalogAPI_BLL.Models;
using CatalogAPI_DAL.Context;
using CatalogAPI_DAL.Interfaces.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Repositories.Mongo
{
    public class CategoryMongoRepository : MongoGenericRepository<Categories>, ICategoryMongoRepository
    {
        public CategoryMongoRepository(IMongoDBContext mongoDBContext) : base(mongoDBContext)
        {
        }
    }
}
