using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;

namespace DDD.Domain.Services
{
    public class CustomerService: ServiceBase<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;   

        public CustomerService(ICustomerRepository customerRepository):base(customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetSpecialCustomer(IEnumerable<Customer> customerList)
        {
            return customerList.Where(c=> c.SpecialCustomer(c));
        }
  }
}