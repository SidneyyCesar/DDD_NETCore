using DDD.Domain.Entities;

namespace DDD.Domain.Interfaces.Repositories
{
    public interface IProductRepository: IRepositoryBase<Product> 
    {
        IEnumerable<Product> ListByName(string name);

    }
}