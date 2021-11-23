using CatalogAPI_BLL.Models;
using CatalogAPI_DAL.Interfaces.Mongo;
using CatalogAPI_DAL.UoW;
using CatalogAPI_SERVICES.Interfaces;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI_SERVICES.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductMongoRepository _productMongoRepository;
        private readonly IUnitOfWork _unityOfWork;
        public ProductServices(IProductMongoRepository productMongoRepository, IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            _productMongoRepository = productMongoRepository;
        }

        public async Task<Product> ChangeProduct(Product product)
        {
            await _productMongoRepository.UpdateAsync(product);
            await _unityOfWork.CommitAsync();

            return product;
        }

        public async Task DeleteProduct(ObjectId id)
        {
            await _productMongoRepository.DeleteAsync(id);
            await _unityOfWork.CommitAsync();
        }

        public async Task<Product> GetProductById(ObjectId id)
        {
            return await _productMongoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productMongoRepository.GetAllAsync();
        }

        public async Task<Product> SaveProduct(Product product)
        {
            await _productMongoRepository.AddAsync(product);
            await _unityOfWork.CommitAsync();

            return product;
        }
    }
}
