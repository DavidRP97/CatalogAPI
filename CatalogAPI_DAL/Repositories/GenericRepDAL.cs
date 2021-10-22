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
    public class GenericRepDAL<TEntity> : IGenericDAL<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _appDbContext.Set<TEntity>().RemoveRange(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return await _appDbContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task<TEntity> GetById(int id)
        {
            try
            {
                return await _appDbContext.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task Insert(TEntity entity)
        {
            try
            {
                await _appDbContext.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
        public async Task Update(TEntity entity)
        {
            try
            {
                var update = _appDbContext.Set<TEntity>().Update(entity);
                update.State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}
