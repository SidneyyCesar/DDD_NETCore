using DDD.Data.Context;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;

namespace DDD.Data.Repositories
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
       public ProductRepository(ContextSettings context):base(context){ }

        public IEnumerable<Product> ListByName(string name)
        {
            return _context.Products.Where(p => p.Name == name);
        }
  }
}