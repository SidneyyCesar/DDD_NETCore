using DDD.Domain.Entities;

namespace DDD.Application.Interfaces
{
    public interface ICustomerApplicationService: IApplicationService<Customer>
    {
         IEnumerable<Customer> GetSpecialCustomers();
    }
}