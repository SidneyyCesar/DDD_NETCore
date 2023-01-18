using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Services;

namespace DDD.Application.Services
{
   public class ProductApplicationService: ApplicationService<Product>, IProductApplicationService
    {
        private readonly IProductService _productService;
        public ProductApplicationService(IProductService ProductService)
            :base(ProductService)
        {
            _productService = ProductService;
        }

        public IEnumerable<Product> ListByName(string name)
        {
            return _productService.ListByName(name);
        }
  }
}