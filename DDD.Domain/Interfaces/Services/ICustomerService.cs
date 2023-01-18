using DDD.Domain.Entities;

namespace DDD.Domain.Interfaces.Services
{
    public interface ICustomerService: IServiceBase<Customer>
    {
         IEnumerable<Customer> GetSpecialCustomer(IEnumerable<Customer> customer);
    }
}