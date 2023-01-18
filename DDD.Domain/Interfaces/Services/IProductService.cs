using DDD.Domain.Entities;

namespace DDD.Domain.Interfaces.Services
{
    public interface IProductService: IServiceBase<Product>
    {
         IEnumerable<Product> ListByName(string name);
    }
}