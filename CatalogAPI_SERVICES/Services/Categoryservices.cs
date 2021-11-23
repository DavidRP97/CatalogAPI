using CatalogAPI_BLL.Models;
using CatalogAPI_DAL.Interfaces.Mongo;
using CatalogAPI_DAL.UoW;
using CatalogAPI_SERVICES.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI_SERVICES.Services
{
    public class Categoryservices : ICategoryServices
    {
        private readonly ICategoryMongoRepository _categoryMongoRepository;
        private readonly IUnitOfWork _unityOfWork;
        public Categoryservices(ICategoryMongoRepository categoryMongoRepository, IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            _categoryMongoRepository = categoryMongoRepository;
        }
        public async Task<Categories> ChangeCategory(Categories categories)
        {
            await _categoryMongoRepository.UpdateAsync(categories);
            await _unityOfWork.CommitAsync();

            return categories;
        }

        public async Task DeleteCategory(ObjectId id)
        {
            await _categoryMongoRepository.DeleteAsync(id);
            await _unityOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Categories>> GetCategories()
        {
            return await _categoryMongoRepository.GetAllAsync();
            
        }

        public async Task<Categories> GetCategorytById(ObjectId id)
        {
            return await _categoryMongoRepository.GetByIdAsync(id);
        }

        public async Task<Categories> SaveCategory(Categories categories)
        {
            await _categoryMongoRepository.AddAsync(categories);
            await _unityOfWork.CommitAsync();

            return categories;
        }
    }
}
