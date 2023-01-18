using DDD.Data.Context;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;

namespace DDD.Data.Repositories
{
    public class ProdutoRepository: RepositoryBase<Product>, IProductRepository
    {
       public ProdutoRepository(ContextSettings context):base(context){ }

        public IEnumerable<Product> ListByName(string name)
        {
        throw new NotImplementedException();
        }
  }
}