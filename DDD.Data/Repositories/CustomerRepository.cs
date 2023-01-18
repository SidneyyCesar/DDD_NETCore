using DDD.Data.Context;
using DDD.Domain.Entities;
using DDD.Domain.Interfaces.Repositories;

namespace DDD.Data.Repositories
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ContextSettings context):base(context){ }
    }
}