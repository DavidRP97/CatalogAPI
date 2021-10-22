using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Interfaces
{
    public interface IGenericDAL<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Delete(int id);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
    }
}
