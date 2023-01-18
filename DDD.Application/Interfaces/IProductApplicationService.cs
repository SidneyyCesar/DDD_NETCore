using DDD.Domain.Entities;

namespace DDD.Application.Interfaces
{
    public interface IProductApplicationService: IApplicationService<Product>
    {
         IEnumerable<Product> ListByName(string name);
    }
}