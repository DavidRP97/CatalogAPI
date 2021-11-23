using CatalogAPI_DAL.Context;
using CatalogAPI_DAL.Interfaces.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using ServiceStack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Repositories.Mongo
{
    public abstract class MongoGenericRepository<TEntity> : IMongoGenericRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDBContext _mongoDBContext;
        protected IMongoCollection<TEntity> DbSet;
        protected MongoGenericRepository(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            DbSet = _mongoDBContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            _mongoDBContext.AddCommand(() => DbSet.InsertOneAsync(entity));
        }

        public virtual async Task<TEntity> GetByIdAsync(ObjectId id)
        {
            var entity = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));

            return entity.FirstOrDefault();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entity = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);

            return entity.ToList();
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            _mongoDBContext.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity));
        }

        public virtual async Task DeleteAsync(ObjectId id)
        {
            _mongoDBContext.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            _mongoDBContext?.Dispose();
        }
    }
}
