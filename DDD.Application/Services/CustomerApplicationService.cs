using DDD.Application.Interfaces;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Services;

namespace DDD.Application.Services
{
    public class CustomerApplicationService: ApplicationService<Customer>, ICustomerApplicationService
    {
        private readonly ICustomerService _customerService;
        public CustomerApplicationService(ICustomerService customerService)
            :base(customerService)
        {
            _customerService = customerService;
        }

        public IEnumerable<Customer> GetSpecialCustomers()
        {
            return _customerService.GetSpecialCustomer(_customerService.List());
        }
    }
}