using CatalogAPI_DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoDBContext _mongoDBContext;
        public UnitOfWork(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }
        //PODE-SE USAR O SAVE CHANGES AQUI
        public async Task<bool> CommitAsync()
        {
            var qttChanges = await _mongoDBContext.SaveChanges();

            return qttChanges > 0;
        }

        public void Dispose()
        {
            _mongoDBContext.Dispose();
        }
    }
}
