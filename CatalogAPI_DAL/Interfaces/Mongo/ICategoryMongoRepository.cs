using CatalogAPI_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Interfaces.Mongo
{
    public interface ICategoryMongoRepository : IMongoGenericRepository<Categories>
    {
    }
}
