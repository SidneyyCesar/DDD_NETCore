using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;

namespace DDD.Domain.Services
{
    public class ProductService: ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;   

        public ProductService(IProductRepository ProductRepository):base(ProductRepository)
        {
            this._productRepository = ProductRepository;
        }
        public IEnumerable<Product> ListByName(string name)
        {
            return this._productRepository.ListByName(name);
        }
  }
}