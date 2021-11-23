using CatalogAPI_BLL.Models;
using CatalogAPI_DAL.Repositories.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Interfaces.Mongo
{
    public interface IProductMongoRepository : IMongoGenericRepository<Product>
    {

    }
}
