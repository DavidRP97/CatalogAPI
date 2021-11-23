using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.Context
{
    public class MongoDBContext : IMongoDBContext
    {
        private IConfiguration _configuration { get; set; }
        private IMongoDatabase _mongoDatabase { get; set; }
        public IClientSessionHandle _clientSession { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _command;
        public MongoDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _command = new List<Func<Task>>();
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (_clientSession = await MongoClient.StartSessionAsync())
            {
                _clientSession.StartTransaction();

                var commandTasks = _command.Select(func => func());

                await Task.WhenAll(commandTasks);

                await _clientSession.CommitTransactionAsync();
            }

            return _command.Count();
        }
        public void AddCommand(Func<Task> func) => _command.Add(func);

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            ConfigureMongo();

            return _mongoDatabase.GetCollection<TEntity>(name);
        }

        public void Dispose()
        {
            _clientSession?.Dispose();
            GC.SuppressFinalize(this);
        }

        private void ConfigureMongo()
        {
            if (MongoClient != default)
                return;

            MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);
            _mongoDatabase = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);
        }
    }
}
