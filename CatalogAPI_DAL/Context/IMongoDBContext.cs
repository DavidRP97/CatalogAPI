using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Context
{
    public interface IMongoDBContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}
