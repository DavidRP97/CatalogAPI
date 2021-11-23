using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Interfaces.Mongo
{
    public interface IMongoGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(ObjectId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(ObjectId id);
    }
}
